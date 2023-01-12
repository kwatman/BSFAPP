import {createContext, useState} from "react";

const AuthContext = createContext({});


export function AuthProvider({children}){
    const [auth, setAuth] = useState(null);

    const doLogin = (token) => {
        setAuth(token);
    }

    return(
        <AuthContext.Provider  value={{auth,setAuth,doLogin}}>
            {children}
        </AuthContext.Provider>
    )
}



export default AuthContext