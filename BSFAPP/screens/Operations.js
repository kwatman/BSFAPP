import {Button, Pressable, SafeAreaView, ScrollView, Text, View} from "react-native";
import {globalStyles} from "../styles/global";
import OperationCard from "../components/OperationCard";
import React, {useContext, useEffect, useState} from "react";
import AppSettings from "../AppSettings";
import AuthContext from "../context/AuthContext";

function Operations({ navigation })  {

    const [operations,setOperations] = useState({pastOperations: null, upcomingOperations: null})
    const {auth,doLogin} = useContext(AuthContext)
    
    const operationPressed = (operation) => {
        console.log(operation.codeName)
    }
    
    useEffect(() => {
        async function loadOps(){
            try {
                let response =  await fetch(AppSettings.serverUrl +'api/operations', {
                    method: 'GET',
                    headers: {
                        'Authorization':'Bearer ' + auth.token,
                        'Accept': 'application/json',
                        'Content-type': 'application/json'
                    },
                })
                let data = await response.json()
                let pastOperations= []
                data.data.forEach((operation) =>{
                        let zerohour = new Date(operation.zeroHour)
                        operation.zeroHour = zerohour.toLocaleString()
                        pastOperations.push(operation)
                    }
                );
                pastOperations = data.data.map((operation) =>
                    <Pressable style={{width: '80%', alignItems: 'center'}} onPress={() => operationPressed(operation)}>
                        <OperationCard key={operation.id} title={operation.codeName} date={operation.zeroHour}/>
                    </Pressable>
                );
                
                let upcomingOperations =[]
                
                let operations = {
                    pastOperations: pastOperations,
                    upcomingOperations: upcomingOperations
                }
                setOperations(operations)
            }catch (error) {
                console.error(error);
            }
        }
        loadOps()
        console.log(auth.data.role)
    }, [])
    
    return(
        <SafeAreaView style ={globalStyles.baseContainer}>
            <ScrollView style={{width: '100%'}} contentContainerStyle={{ alignItems: 'center'}}>
                {auth.data.role === "Admin" ?     
                    <Pressable style={globalStyles.button} onPress={() => navigation.navigate('AddOperation')}>
                        <Text style={globalStyles.buttonText}>add new opperation</Text>
                    </Pressable>
                    :
                    null
                }

                <Text style={{color: 'white'}}> Upcoming Operation</Text>
                {operations.upcomingOperations == null ? operations.upcomingOperations :  <Text style={{color: 'white'}}> There are no upcoming operations</Text>}
                <View
                    style={{
                        borderBottomColor: 'white',
                        borderBottomWidth: 1,
                        margin:20,
                        width: '80%'
                    }}
                />
                {operations.pastOperations}
            </ScrollView> 
        </SafeAreaView>
    )
}

export default Operations