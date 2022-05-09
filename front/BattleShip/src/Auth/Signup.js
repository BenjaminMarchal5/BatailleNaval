import {  useState } from 'react';
import {  useHistory } from 'react-router-dom';
import { Button, Form, Container} from 'react-bootstrap';
import { useAuth } from "./auth.js";

let Signup = () => {
    let history = useHistory();
    let [email, setEM] = useState("");
    let [firstname, setFN] = useState("");
    let [lastname, setLN] = useState("");
    let [password, setP] = useState("");
    let [password2, setP2] = useState("");
    let [error, setError] = useState("");

    let signupClick = () => {
        signup(email, firstname, lastname, password, password2).then(res => { history.push("/Signin"); }).catch(error => { setError(error + ""); });
    };

    const { signup } = useAuth();
    return <>
        <div className="home" style={{ paddingTop: '10%' }}>
            <Container>
                <div className="signup-glass">
                    <Form.Group controlId="formBasicEmail">
                        <Form.Label>Email</Form.Label>
                        <Form.Control type="email" onChange={(e) => { setEM(e.target.value); }} />
                        <Form.Text className="text-muted">
                            Votre mail ne sera pas communiqué en dehors de notre plateforme.
                        </Form.Text>
                    </Form.Group>

                    <Form.Group controlId="exampleForm.ControlText1">
                        <Form.Label>Prénom</Form.Label>
                        <Form.Control type="text" onChange={(e) => { setFN(e.target.value); }} />
                    </Form.Group>
                    <Form.Group controlId="exampleForm.ControlText2">
                        <Form.Label>Nom</Form.Label>
                        <Form.Control type="text" onChange={(e) => { setLN(e.target.value); }} />
                    </Form.Group>
                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Mot de passe</Form.Label>
                        <Form.Control type="password" onChange={(e) => { setP(e.target.value); }} />
                    </Form.Group>
                    <Form.Group controlId="formBasicPassword">
                        <Form.Label>Vérification du mot de passe</Form.Label>
                        <Form.Control type="password" onKeyDown={(e) => {
                        if (e.code === "Enter") {
                            signupClick();
                        }
                    }} onChange={(e) => { setP2(e.target.value); }} />
                    </Form.Group>
                    {error !== "" ?
                        <p style={{ color: 'red' }}>{error}</p>
                        : null}
                    <Button style={{ backgroundColor: '#FC9F09', border: 'none', float: 'right' }} onClick={() => {
                        signupClick();
                    }}>M'inscrire
                    </Button>
                </div>
            </Container>
        </div>

    </>
};

export { Signup };