/* eslint-disable @typescript-eslint/restrict-plus-operands */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
/* eslint-disable @typescript-eslint/no-unsafe-call */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-return */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import axios from "axios";
import { useMutation } from "react-query";
import { useNavigate, useLocation } from "react-router";
import { LoginModel, fakeAuthProvider } from "../api/auth";
import React from "react";
import { useAuth } from "../context/auth";
import "./Login.css"
import { ToastContainer, toast } from "react-toastify";
import { ColorRing } from "react-loader-spinner";

export function LoginPage() {
    const navigate = useNavigate();
    const location = useLocation();
    const auth = useAuth();
    //const {mutate} = usePosts();
    const mutation = useMutation({
        mutationFn: (loginModel: LoginModel) => {
            return axios.post(import.meta.env.VITE_API_BASEURL + '/Authenticate/login', loginModel)
        },
    })

    // if (!mutation.isLoading) {
    //     console.log(mutation.data);

    //     if (mutation.isError) {
    //         console.log(mutation.error);
    //     }
    //     else if (mutation.isSuccess) {

    //     }
    // }

    function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);
        const username = formData.get("username") as string;
        const password = formData.get("password") as string;

        mutation.mutate({ username, password }, {
            onSuccess: (data) => {
                console.log(data);

                auth.user = username;
                const token = data?.data?.token;
                localStorage.setItem('token', token);

                navigate(location.state?.from?.pathname || "/protected", { replace: true });
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
            {!auth.user?  
                <h2 className="flexCenter">Please Login</h2>:
                null
            }
            <form onSubmit={handleSubmit} className="loginDiv">
                <label>
                    Username: <input name="username" type="text" />
                </label>{" "}
                <label>
                    Password: <input name="password" type="password" />
                </label>{" "}
                <button type="submit">Login</button>
            </form>
            <p className="hoverBtn" onClick={() => registerClick(navigate)}>Register</p></>  
            }
        </div>
    );
}

function registerClick(navigate: any) {
    console.log("register");

    navigate("/register", { replace: true });
}
// const LoginPage = () => {
//     const {
//       register,
//       handleSubmit,
//       formState: { errors },
//     } = useForm<LoginForm>();
  
//     const toast = useToast();
//     const login = useLoginFromCall();
//     const navigate = useNavigate();
//     const location = useLocation();
//     const from = location.state?.from?.pathname || "/";
  
//     const { mutate, isLoading } = useApiPost("auth", undefined, publicAxios.post);
  
//     const onSubmit = async (data: LoginForm) => {
//       // if missing email or password
//       mutate(data, {
//         onSuccess: (response) => {
//           // Set the auth token and refresh token
//           login(response.data);
//           // Send them back to the page they tried to visit when they were
//           // redirected to the login page. Use { replace: true } so we don't create
//           // another entry in the history stack for the login page.  This means that
//           // when they get to the protected page and click the back button, they
//           // won't end up back on the login page, which is also really nice for the
//           // user experience.
//           navigate(from, { replace: true });
//           // toast("Login successful", "success");
//         },
//         onError: (error: any) => {
//           toast(error.message, "error");
//         },
//       });
//     };
  
//     return (
//       <Card title="Login" icon={<div></div>}>
//         <form onSubmit={handleSubmit(onSubmit)}>
//           <Input
//             error={errors.email}
//             label="email"
//             register={register}
//             pattern={{ value: /^\S+@\S+.\S+$/i, message: "Email Invalid" }}
//             required
//           />
//           <Input
//             type="password"
//             error={errors.password}
//             label="password"
//             register={register}
//             required
//           />
//           <button type="submit">{isLoading ? <Spinner /> : "Login"}</button>
//         </form>
//       </Card>
//     );
//   };