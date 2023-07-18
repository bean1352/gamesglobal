/* eslint-disable @typescript-eslint/restrict-plus-operands */
import axios from "axios";
import { useMutation, useQuery } from "react-query";

const fakeAuthProvider = {
    isAuthenticated: false,
    signin(callback: VoidFunction) {
        fakeAuthProvider.isAuthenticated = true;
        setTimeout(callback, 100); // fake async
    },
    signout(callback: VoidFunction) {
        fakeAuthProvider.isAuthenticated = false;
        setTimeout(callback, 100);
    },
};

type AuthResponse = {
    data:
    {
        token: string;
    }
};

export type LoginModel = {
    username: string;
    password: string;
};

export type RegisterModel = {
    username: string;
    email: string;
    password: string;
};

function usePosts() {
    const mutation = useMutation({
        mutationFn: (loginModel: LoginModel) => {
            return axios.post(import.meta.env.VITE_API_BASEURL + '/Authenticate/login', loginModel)
        },
    })

    return mutation;
}

export { fakeAuthProvider, usePosts };