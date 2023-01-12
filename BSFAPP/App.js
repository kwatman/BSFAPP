import React, {useContext} from 'react';

import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import Home from "./screens/Home";
import Login from "./screens/Login";
import Header from "./components/Header";
import AuthContext from "./context/AuthContext";

const Stack = createNativeStackNavigator();
function App() {
    const {auth,doLogin} = useContext(AuthContext)
    return auth ? (
        <NavigationContainer>
            <Stack.Navigator>
                <Stack.Screen name="Home" component={Home}/>
            </Stack.Navigator>
        </NavigationContainer>
    ): (
        <NavigationContainer>
            <Stack.Navigator>
                <Stack.Screen name="Login" 
                              component={Login} 
                              options={{header: (props) => <Header title="Login" {...props}/>}}/>
            </Stack.Navigator>
        </NavigationContainer>
    );
};


export default App;
