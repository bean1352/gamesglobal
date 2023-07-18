/* eslint-disable @typescript-eslint/restrict-plus-operands */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-return */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import axios from "axios";
import { useMutation } from "react-query";
import { useNavigate, useLocation } from "react-router";
import { RegisterModel, fakeAuthProvider } from "../api/auth";
import React from "react";
import { useAuth } from "../context/auth";
import "./Login.css"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { ColorRing } from "react-loader-spinner";

export function RegisterPage() {
    const navigate = useNavigate();
    const location = useLocation();
    const auth = useAuth();
    //const {mutate} = usePosts();
    const mutation = useMutation({
        mutationFn: (registerModel: RegisterModel) => {
            return axios.post(import.meta.env.VITE_API_BASEURL + '/Authenticate/register', registerModel)
        },
    })

    if (!mutation.isLoading) {
        console.log(mutation.data);

        if (mutation.isError) {
            console.log(mutation.error);
        }
        else if (mutation.isSuccess) {
            console.log(mutation.data.data);
            const token = mutation.data?.data?.token;
            localStorage.setItem('token', token);
        }
    }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);
        const username = formData.get("username") as string;
        const email = formData.get("email") as string;
        const password = formData.get("password") as string;

        mutation.mutate({ username, email, password }, {
            onSuccess: (data) => {
                console.log(data);

                auth.user = username;
                toast("Registration Successful!");
                navigate(location.state?.from?.pathname || "/login", { replace: true });
            },
            onError: (error: any) => {
                console.log(error);
                toast(error?.message);
            }
        });
    }

    return (
        <div>
            {mutation.isLoading ?
                <ColorRing
                    visible={true}
                    height="80"
                    width="80"
                    ariaLabel="blocks-loading"
                    wrapperStyle={{}}
                    wrapperClass="blocks-wrapper"
                    colors={['#b8c480', '#B2A3B5', '#F4442E', '#51E5FF', '#429EA6']}
                /> :
                <>
                    <ToastContainer />
                    {!auth.user ?
                        <h2 className="flexCenter">Register</h2> :
                        null
                    }
                    <form onSubmit={handleSubmit} className="loginDiv">
                        <label>
                            Username: <input name="username" type="text" />
                        </label>{" "}
                        <label>
                            Email: <input name="email" type="text" />
                        </label>{" "}
                        <label>
                            Password: <input name="password" type="password" />
                        </label>{" "}
                        <button type="submit">Register</button>
                    </form>
                    <p className="hoverBtn" onClick={() => loginClick(navigate)}>Login</p>
                </>
            }
        </div>
    );
}
function loginClick(navigate: any) {
    console.log("login");

    navigate("/login", { replace: true });
}