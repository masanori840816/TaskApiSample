import { useContext, useEffect } from "react"
import "./Index.page.css";
import { AppUserContext } from "./users/appUserContext"

export function IndexPage(): JSX.Element {
    const appUsers = useContext(AppUserContext);
    useEffect(() => {
        console.log("indexpage ");
    }, []);
    return <div>
        <h1>Hello World!</h1>
        <div>{appUsers?.name ?? ""}</div>
    </div>
}