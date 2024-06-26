import React, {useContext} from 'react'
import {Box, CircularProgress} from '@mui/material'
import {observer} from "mobx-react-lite";
import {useNavigate} from "react-router-dom";
import {AppStoreContext} from "../../App";
import Form from "../../components/Form";
import RegisterStore from "../../stores/RegisterStore";

const Register = () => {
    const appStore = useContext(AppStoreContext);
    const store = React.useMemo(() => new RegisterStore(appStore.authStore), [appStore.authStore]);
    const navigate = useNavigate()

    const onEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        store.changeEmail(e.target.value)
    }

    const onPasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        store.changePassword(e.target.value)
    }

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()
        await store.register()
        !store.error && navigate("/home")
    }

    return (
        <Box
            sx={{
                marginTop: 8,
                display: 'flex',
                flexGrow: 1,
                flexDirection: 'column',
                alignItems: 'center',
            }}
        >
            {store.isLoading ? (
                <CircularProgress />
            ) : ( <Form
                title={"Create account"}
                inputs={[
                    {
                        name: "email",
                        label: "Email",
                        type: 'email',
                        onChange: onEmailChange
                    },
                    {
                        name: "password",
                        label: "Password",
                        type: "password",
                        onChange: onPasswordChange
                    }]}
                buttonText={"Add"}
                handleSubmit={handleSubmit} />)}
            {store.error && <p style={{color: 'red', fontSize: 14}}>{`Error: ${store.error}`}</p>}
            {appStore.authStore.token && (
                <p className="mt-3 mb-3" style={{ color: 'green', fontSize: 14, fontWeight: 700 }}>{`Success! Token is: ${appStore.authStore.token}`}</p>
            )}
        </Box>
    )
}

export default observer(Register)