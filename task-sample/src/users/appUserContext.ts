import React from "react";
import { AppUser } from "./appUser";

const AppUserContext = React.createContext<AppUser|null>(null);

export { AppUserContext };