import { useHistory } from "react-router-dom";
import {Button} from 'react-bootstrap';

let Home=()=>{
    let history = useHistory();
    return <div>
        <h1>Home</h1>
        <Button onClick={()=>{history.push('/signup');}}>S'inscrire</Button>
        <Button onClick={()=>{history.push('/signin');}}>Se connecter</Button>
    </div>;
};
export {Home}