/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-return */
import { Link, Outlet, useNavigate } from "react-router-dom";
import { useAuth } from "../context/auth";
import "./Layout.css"

export function Layout() {
    return (
        <div className="container">
            <AuthStatus />

            {/* <ul>
                <li>
                    <Link to="/">Public Page</Link>
                </li>
                <li>
                    <Link to="/protected">Protected Page</Link>
                </li>
            </ul> */}

            <Outlet />
        </div>
    );
}

function AuthStatus() {

    // eslint-disable-next-line @typescript-eslint/no-unsafe-assignment
    const navigate = useNavigate();
    const auth = useAuth();

    // if (!auth.user) {
    //     return <h2 className="flexCenter">You are not logged in.</h2>;
    // }

    return (
        <div className="layoutContainer">

            {/* {auth.user ?
                <button
                    onClick={() => {
                        auth.user = null;
                        auth.signout(() => navigate("/login"));
                    }}
                >
                    Sign out
                </button> : null
            } */}
        </div>
    );
}