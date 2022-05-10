import { Switch, Route, useHistory, useLocation } from "react-router-dom";
import { NavMenu } from './Component/NavMenu.js';
import { roleUserVerif } from './Utils/FunctionUtils.js';
import { Tooltip } from 'react-bootstrap';
import { Home } from './Component/Home.js';
import { Signin } from './Auth/Signin.js';
import { Signup } from './Auth/Signup.js';
import { Role } from './Utils/Role.js';
import { AddToBreadCrumb } from './Utils/FunctionUtils.js';
import { useState, useEffect } from 'react';
import { Error404 } from './Component/Error404';
import { AuthorizationError } from './Component/AuthorizationError';
import { DashBoard } from './Component/DashBoard';


let BattleShip = () => {
    return <Switch>

        {
            /*
            <Route exact path="/challenge/create">
                    <Role role={roleUserVerif.admin} redirection={true}>
                        <NavMenu />
                    </Role>
                </Route>
                
              <Route exact path="/user">
                    <Role role={roleUserVerif.user} redirection={true}>
                        <NavMenu />
                        <UserAccount />
                    </Role>
                </Route>
            */
        }

        <Route exact path="/Dashboard">
            <Role role={roleUserVerif.user} redirection={true}>
                <NavMenu />
                <DashBoard />
            </Role>
        </Route>

        <Route exact path="/signin">
            <Signin />
        </Route>
        <Route exact path="/signup">
            <Signup />
        </Route>
        <Route exact path="/">
            <Home />
        </Route>

        <Route path="/error">
            <AuthorizationError />
        </Route>
        <Route path="/">
            <Error404 />
        </Route>
    </Switch>;
}


export { BattleShip };
