import { useHistory } from "react-router-dom";
import { useAuth } from "../Auth/auth.js";


let Role = ({ children, role, redirection, exact }) => {
    const { user } = useAuth();
    let history = useHistory();
    let ok = true;
    if (user != null) {
        if (exact == null || !exact) {
            var split = role.split(",");
            if (split.indexOf(user.role.toUpperCase()) < 0) {
                if (redirection) {
                    history.push('/Signup');
                    return;
                }
                else {
                    ok = false;
                }
            }
        }
        else if (exact != null && exact) {
            let nb = 0;
            for (let i = 0; i < role.length; i++) {
                if (role[i].toUpperCase() == user.role.toUpperCase()) {
                    nb++;
                }
            }

            if (nb == 0) {
                if (redirection) {
                    history.push('/Signup');
                    return;
                }
                else {
                    ok = false;
                }
            }
        }

    }
    else {
        if (redirection) {
            history.push("/signin");
            return null;
        }
    }
    return <>{ok ?
        <>{children}</>
        : null
    }</>;
};

export { Role };