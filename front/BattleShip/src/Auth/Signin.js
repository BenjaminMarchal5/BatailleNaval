import { useState } from 'react';
import { useHistory } from 'react-router-dom';
import { Button, Form, Container } from 'react-bootstrap';
import { useAuth } from "./auth.js";
import { useMutation } from 'react-query';
import '../Css/Signin.css';

let Signin = () => {
    let history = useHistory();
    let [email, setEM] = useState("");
    let [password, setP] = useState("");
    let [error, setError] = useState("");

    const { signin } = useAuth();

    let signinClick = () => {
        signin(email, password)
            .then(() => { history.push("/Dashboard"); })
            .catch(error => { setError(error + ""); });
    };

    return <div style={{ paddingTop: '13%' }}>
        <Container>
            <div className="glass">
                <Form.Group controlId="formBasicEmail">
                    <Form.Label>Email</Form.Label>
                    <Form.Control type="email" onKeyDown={(e) => {
                        if (e.code === "Enter") {
                            signinClick();
                        }
                    }} onChange={(e) => { setEM(e.target.value); }} />
                </Form.Group>
                <Form.Group controlId="formBasicPassword">
                    <Form.Label>Mot de passe</Form.Label>
                    <Form.Control type="password" onKeyDown={(e) => {
                        if (e.code === "Enter") {
                            signinClick();
                        }
                    }} onChange={(e) => { setP(e.target.value); }} />
                </Form.Group>
                {error !== "" ?
                    <p style={{ color: 'red' }}>{error}</p>
                    : null}
                <a style={{ fontSize: '0.7rem' }} href={"/Signup"}>Pas encore de compte ?</a>
                <Button style={{ backgroundColor: '#FC9F09', border: 'none', float: 'right' }} onClick={() => {
                    signinClick();
                }}>Me connecter</Button>
            </div>
        </Container>
    </div>;
};

export { Signin };