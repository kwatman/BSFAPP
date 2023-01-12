import {Button, Text, View} from "react-native";


function Home({ navigation })  {
    return(
        <View>
            <Text>Home</Text>
            <Button
                title="Go to login"
                onPress={() => navigation.push('Login')}
            />
        </View>
    )
}

export default Home