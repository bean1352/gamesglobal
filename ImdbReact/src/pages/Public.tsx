import { redirect, useNavigate } from "react-router";

export function PublicPage() {

    redirect('/login');
    return null;
}