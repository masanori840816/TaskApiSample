import React, { ReactNode, useEffect, useState } from 'react';
import { AppUserContext } from "./appUserContext";
import * as users from './appUser';


interface AppUserProviderProps {
    children: ReactNode;
}
const AppUserProvider: React.FC<AppUserProviderProps> = ({children}) => {
    const [appUser, setAppUser] = useState<users.AppUser|null>(null);
    useEffect(() => {
        users.loadAppUser()
            .then(res => {
                if(appUser == null) {
                    setAppUser(res);
                }
            })
            .catch(err => console.error(err));
    }, []);
    return <AppUserContext.Provider value={appUser}>
        {children}
    </AppUserContext.Provider>;
};
export { AppUserProvider};

