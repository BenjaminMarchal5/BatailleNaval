import '../App.css';
import { Container, Nav, NavDropdown, NavLink, Badge } from 'react-bootstrap';
import { useAuth } from '../Auth/auth.js';
import { roleUserVerif } from '../Utils/FunctionUtils.js';
import { useHistory, useLocation } from 'react-router-dom';
//import logoPoulpe from '../Image/poulpe_logo.png';
import { Role } from '../Utils/Role.js';

let NavMenu = () => {
    const { signout, user } = useAuth();
    let history = useHistory();
    let { pathname } = useLocation();
    let deco = () => {
        history.push('/');
    };
    
    return<>{user != null ?
        <div style={{ display: 'flex', flexDirection: 'row', marginRight: '0', marginLeft: '0' }}>
            <NavLink onClick={() => { history.push("/Dashboard") }} style={{ paddingBottom: '0px' }}>
                {
                    /*
                    <img src={logoPoulpe} alt="" style={{ width: '40px', position: 'relative', padding: '0px' }} />
                    */
                }
            </NavLink>
            <NavLink onClick={() => { history.push("/user") }}>
                <Badge variant={"success"}>{user.firstname + " " + user.lastname}</Badge>
            </NavLink>
            <Container>
                <Nav id="navbarMenu" className="menu justify-content-end">
                    <Nav.Item>
                        <NavLink active={pathname === "/Dashboard" ? true : false} onClick={() => { history.push("/Dashboard") }}>Dashboard</NavLink>
                    </Nav.Item>
                    <Nav.Item>
                        <NavLink active={pathname === "/Challenges" ? true : false} onClick={() => { history.push("/Challenges") }}>Challenges</NavLink>
                    </Nav.Item>
                    <Nav.Item>
                        <NavLink active={pathname === "/ThemeToVote" ? true : false} onClick={() => { history.push("/ThemeToVote") }}>Thème</NavLink>
                    </Nav.Item>
                    <Nav.Item>
                        <NavLink active={pathname === "/Boutique" ? true : false} onClick={() => { history.push("/Boutique") }}>Boutique</NavLink>
                    </Nav.Item>
                    <Role role={roleUserVerif.admin}>
                        <NavDropdown active={pathname.indexOf("Admin") > 0 ? true : false} title="Administration" id="nav-dropdown">
                        <NavDropdown.Item active={pathname === "/DashboardAdmin" ? true : false} eventKey="1" onClick={() => { history.push("/DashboardAdmin") }}>Dashboard</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item active={pathname === "/ChallengesAdmin" ? true : false} eventKey="2" onClick={() => { history.push("/ChallengesAdmin") }}>Challenges</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item active={pathname === "/ObstaclesAdmin" ? true : false} eventKey="3" onClick={() => { history.push("/ObstaclesAdmin") }}>Obstacles</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item active={pathname === "/CheatsAdmin" ? true : false} eventKey="4" onClick={() => { history.push("/CheatsAdmin") }}>Fraudes</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item active={pathname === "/ThemesAdmin" ? true : false} eventKey="5" onClick={() => { history.push("/ThemesAdmin") }}>Thèmes</NavDropdown.Item>
                            <NavDropdown.Divider />
                            <NavDropdown.Item active={pathname === "/ThemesSuggestionAdmin" ? true : false} eventKey="6" onClick={() => { history.push("/ThemesSuggestionAdmin") }}>Suggestions de thèmes</NavDropdown.Item>
                            <Role role={roleUserVerif.superAdmin}>
                                <NavDropdown.Divider />
                                <NavDropdown.Item active={pathname === "/UsersAdmin" ? true : false} eventKey="7" onClick={() => { history.push("/UsersAdmin") }}>Utilisateurs</NavDropdown.Item>
                            </Role>
                        </NavDropdown>
                    </Role>
                    <NavDropdown active={pathname === "/user" ? true : false} title="Compte" id="nav-dropdown">
                        <NavDropdown.Item active={pathname === "/user" ? true : false} eventKey="1" onClick={() => { history.push("/user") }}>Mon compte</NavDropdown.Item>
                        <NavDropdown.Divider />
                        <Role role={roleUserVerif.user}>
                            <NavDropdown.Item eventKey="3" onClick={() => { signout(deco) }}>Déconnexion</NavDropdown.Item>
                        </Role>


                    </NavDropdown>
                </Nav>
            </Container>
        </div>
        : null
    }</>;
};

export { NavMenu };