import {createContext, useContext, useEffect, useState} from "react";
import AppSettings from "../AppSettings";
const AuthContext = createContext({});
import jwtDecode from "jwt-decode";
import AsyncStorage from '@react-native-async-storage/async-storage';
import OperationCard from "../components/OperationCard";


export function AuthProvider({children}){
    const [auth, setAuth] = useState(null);
    const [isReady, setIsReady] = useState(false);

    const doLogin = async (token) => {
        let decoded = jwtDecode(token)

        let newAuth = {
            token: token,
            data: decoded
        }
        await AsyncStorage.setItem('token', "")
        setAuth(newAuth);
    }

    useEffect(() => {
        async function loadAuth(){
            try {
                let token = await AsyncStorage.getItem('token')
                console.log("AuthProvider: " + token)
                if(token !== null && token){
                    await doLogin(token)
                }
                setIsReady(true)
            } catch (e) {
                console.log(e)
            }
        }
        loadAuth()
    }, [])
    return(
        <AuthContext.Provider  value={{auth,setAuth,doLogin}}>
            {isReady ? children : null}
        </AuthContext.Provider>
    )
}



export default AuthContext