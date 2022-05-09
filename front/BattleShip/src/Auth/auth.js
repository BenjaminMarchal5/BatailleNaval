import { createContext, useContext, useEffect, useState } from "react";
import { useQueryClient } from "react-query";
import { useHistory } from "react-router-dom";
import { eventsAPI } from '../Utils/eventsApi.js';
import { roleUser, roleUserVerif, stateChallenge } from '../Utils/FunctionUtils.js';

const AuthContext = createContext();

function useLocalStorage(key, initialValue) {
    // State to store our value
    // Pass initial state function to useState so logic is only executed once
    const [storedValue, setStoredValue] = useState(() => {
      try {
        // Get from local storage by key
        const item = window.localStorage.getItem(key);
        // Parse stored json or if none return initialValue
        return item ? JSON.parse(item) : initialValue;
      } catch (error) {
        // If error also return initialValue
        console.log(error);
        return initialValue;
      }
    });
    // Return a wrapped version of useState's setter function that ...
    // ... persists the new value to localStorage.
    const setValue = (value) => {
      try {
        // Allow value to be a function so we have same API as useState
        const valueToStore =
          value instanceof Function ? value(storedValue) : value;
        // Save state
        setStoredValue(valueToStore);
        // Save to local storage
        window.localStorage.setItem(key, JSON.stringify(valueToStore));
      } catch (error) {
        // A more advanced implementation would handle the error case
        console.log(error);
      }
    };
    return [storedValue, setValue];
  }

export function AuthProvider({ children }) {
    const [user, setUser] = useLocalStorage("user",null);
    const [userCheck, setUserCheck] = useState(false);
    let client = useQueryClient();
    let history = useHistory();

    useEffect(() => {
        setUserCheck(true);
        let token = window.localStorage.getItem('token');
        if (token != null) {
            eventsAPI.whoami(token)
                .then(user => {
                    setUser(user);
                    setUserCheck(false);
                })
                .catch(() => {
                    setUserCheck(false);
                    setUser(null)
                    window.localStorage.removeItem('token');
                    history.push("/");
                })
        }
        else {
            setUserCheck(false);
            setUser(null)
            window.localStorage.removeItem('token');

        }

    }, []);



    const signup = (Email, Name, LastName, Password, DateOfBirth,PhoneNumber) => {
        return eventsAPI.signup({ Email, Password, Name, LastName, Password,DateOfBirth,PhoneNumber }).catch(error => { throw error; });
    };

    let prefetchQuery = async (user) => {
        /*
        //SessionsListe
        await client.prefetchQuery('getSessionsForUser/' + user.id, async () => { return await eventsAPI.getSessionsForUser(user.id).catch(error => { console.log(error); }) });
        //dashbordChallenge
        await client.prefetchQuery('getRegisterChallenges', async () => { return await eventsAPI.getRegisterChallenges().catch(error => { console.log(error); }) });
        //stats
        await client.prefetchQuery('getChallengerForMe/true', async () => { return await eventsAPI.getChallengerForMe(true).catch(error => { console.log(error); }) });
        await client.prefetchQuery('getObstacleValidationForMe/true', async () => { return await eventsAPI.getObstacleValidationForMe(true).catch(error => { console.log(error); }) });

        //Challenges
        await client.prefetchQuery('getDoableChallenges', async () => { return await eventsAPI.getDoableChallenges().catch(error => { console.log(error); }) });
        await client.prefetchQuery('getFinishChallenges', async () => { return await eventsAPI.getFinishChallenges().catch(error => { console.log(error); }) });

        //themes
        await client.prefetchQuery("getTheme/" + stateChallenge.published.toUpperCase(), async () => { return await eventsAPI.getTheme(stateChallenge.published.toUpperCase()).catch(error => { console.log(error); }); });

        //boutique
        await client.prefetchQuery("getItems", async () => { return await eventsAPI.getItems().catch(error => { console.log(error); }); });

        //Compte
        await client.prefetchQuery("getMyItem", async () => { return await eventsAPI.getMyItem().catch(error => { console.log(error); }); });

        var splitAdmin = roleUserVerif.admin.split(",");
        var splitSuperAdmin = roleUserVerif.superAdmin.split(",");
        if (splitAdmin.indexOf(user.role.toUpperCase()) >= 0) {
            //Dashboard
            await client.prefetchQuery('getCheatsToResolve/false', async () => { return await eventsAPI.getCheatsToResolve(false).catch(error => { console.log(error); }); });
            await client.prefetchQuery('getUsers', async () => { return eventsAPI.getUsers("*").catch(error => { console.log(error) }) });
            await client.prefetchQuery('getAllChallengers', async () => { return await eventsAPI.getAllChallengers().catch(error => { console.log(error); }) });
            await client.prefetchQuery('getAllSessions', async () => { return await eventsAPI.getAllSessions().catch(error => { console.log(error); }) });
            await client.prefetchQuery('getLoginStat', async () => {
                var currentDate = new Date();
                currentDate.setDate(currentDate.getDate() - 7);
                var mm = currentDate.getMonth() + 1;
                var dd = currentDate.getDate();
                dd = dd > 9 ? dd : "0" + dd;
                mm = mm > 9 ? mm : "0" + mm;
                var currentDateString = currentDate.getFullYear() + "-" + mm + "-" + dd;
                return await eventsAPI.getLoginStat(currentDateString).catch(error => { console.log(error); })
            });

            //Challenges
            await client.prefetchQuery('getChallengesByType/' + stateChallenge.edition.toUpperCase(), async () => {
                return await eventsAPI.getChallengesByType(stateChallenge.edition.toUpperCase()).catch(error => { console.log(error); });
            });
            await client.prefetchQuery('getChallengesByType/' + stateChallenge.published.toUpperCase(), async () => {
                return await eventsAPI.getChallengesByType(stateChallenge.published.toUpperCase()).catch(error => { console.log(error); });
            });
            await client.prefetchQuery('getChallengesByType/' + stateChallenge.archived.toUpperCase(), async () => {
                return await eventsAPI.getChallengesByType(stateChallenge.archived.toUpperCase()).catch(error => { console.log(error); });
            });
            //Obstacles
            await client.prefetchQuery('getObstaclesValidate', async () => { return await eventsAPI.getObstaclesValidate().catch(error => { console.log(error); }) });

            //Cheats
            await client.prefetchQuery('getCheats', async () => { return await eventsAPI.getCheats().catch(error => { console.log(error); }) });

            //Themes
            await client.prefetchQuery("getTheme/" + stateChallenge.archived.toUpperCase(), async () => { return await eventsAPI.getTheme(stateChallenge.archived.toUpperCase()).catch(error => { console.log(error); }); });

            //Themes suggestions
            await client.prefetchQuery("getThemesSuggestion", async () => { return await eventsAPI.getThemesSuggestion().catch(error => { console.log(error); }); });
        }
        if (splitSuperAdmin.indexOf(user.role.toUpperCase()) >= 0) {
            //Users
            await client.prefetchQuery('getUserRole/' + roleUser.user, async() => { return await eventsAPI.getUsers(roleUser.user).catch(error => {console.log(error);}) });
            await client.prefetchQuery('getUserRole/' + roleUser.admin, async() => {return await eventsAPI.getUsers(roleUser.admin).catch(error => {console.log(error);}) });
        }
        */
    };

    const signin = (email, password) => {
        return eventsAPI.signin({ email, password })
            .then(token => {
                window.localStorage.setItem('token', token);
                return eventsAPI.whoami(token);
            })
            .then(user => {
                setUser(user);
                client.clear();
                prefetchQuery(user);
            })
            .catch(error => {
                setUser(null);
                window.localStorage.removeItem('token');
                throw error;
            });
    };

    const setNewUser=(user)=>{
        setUser(user);
    }

    const signout = (callback) => {
        setUser(null)
        window.localStorage.removeItem('token');
        callback();
    }

    return <>
        {userCheck ? <p>IsChecking...</p> :
            <AuthContext.Provider value={{ user, signup, signin, signout, setNewUser }}>
                {children}
            </AuthContext.Provider>
        }
    </>;
}

export const useAuth = () => useContext(AuthContext);