import Home from "./Home";
import {Text, StyleSheet, TextInput, View, Button, Pressable} from "react-native";
import React, {useContext} from "react";
import AuthContext from "../context/AuthContext";
import {globalStyles} from "../styles/global";

const Login =  () => {

    const [user, setUser] = React.useState("");
    const [pass, setPass] = React.useState("");
    const {auth,doLogin} = useContext(AuthContext)
    const login = () => {
        doLogin("token")
    }
    return(
        <View style={styles.loginContainer}>
            <Text style={{color: 'white'}}>Please log in to your account</Text>
            <TextInput
                style={globalStyles.textInput}
                onChangeText={setUser}
                value={user}
                placeholder="username"
            />
            <TextInput
                style={globalStyles.textInput}
                onChangeText={setPass}
                value={pass}
                placeholder="password"
            />
            <Pressable style={globalStyles.button} onPress={login}>
                <Text style={globalStyles.buttonText}>LOGIN</Text>
            </Pressable>
        </View>
    )
}

const styles = StyleSheet.create({
    loginContainer: {
        paddingTop: 20,
        flex: 1,
        alignItems: 'center',
        backgroundColor: '#2A2C2E'
    }
});

export default Login