import {Button, SafeAreaView, ScrollView, Text, View} from "react-native";
import {globalStyles} from "../styles/global";
import OperationCard from "../components/OperationCard";
import {useContext, useEffect, useState} from "react";
import AppSettings from "../AppSettings";
import AuthContext from "../context/AuthContext";

function Operations({ navigation })  {

    const [operations,setOperations] = useState(null)
    const {auth,doLogin} = useContext(AuthContext)
    
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
                let newOperations= {}
                
                newOperations = []
                data.data.forEach((operation) =>{
                        let zerohour = new Date(operation.zeroHour)
                        operation.zeroHour = zerohour.toLocaleString()
                        newOperations.push(operation)
                        
                    }
                );
                newOperations = data.data.map((operation) =>
                    <OperationCard key={operation.id} title={operation.codeName} date={operation.zeroHour}/>
                );
                setOperations(newOperations)
            }catch (error) {
                console.error(error);
            }
        }
        loadOps()
    }, [])
    
    return(
        <SafeAreaView style ={globalStyles.baseContainer}>
            <ScrollView style={{width: '100%'}} contentContainerStyle={{ alignItems: 'center'}}>
                <Text style={{color: 'white'}}> Upcoming Operation</Text>
                <OperationCard title="Operation rolling wheels" date="2022-04-01T19:30:00"/>
                <View
                    style={{
                        borderBottomColor: 'white',
                        borderBottomWidth: 1,
                        margin:20,
                        width: '80%'
                    }}
                />
                {operations}
            </ScrollView> 
        </SafeAreaView>
    )
}

export default Operations