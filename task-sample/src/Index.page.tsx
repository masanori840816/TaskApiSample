import { useContext, useEffect } from "react"
import "./Index.page.css";
import { AppUserContext } from "./users/appUserContext"

export function IndexPage(): JSX.Element {
    const appUsers = useContext(AppUserContext);
    useEffect(() => {
        console.log("indexpage ");
        fetch("http://localhost:5155/account/login", {
            mode: "cors",
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ email: "sample@example.com", password: "sample" }),
        })
        .then(res => res.json())
        .then(res => console.log(res))
        .catch(err => console.error(err));
    }, []);
    return <div>
        <h1>Hello World!</h1>
        <div>{appUsers?.name ?? ""}</div>
    </div>
}