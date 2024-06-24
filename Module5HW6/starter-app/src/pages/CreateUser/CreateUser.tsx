import React, {ReactElement, FC, useState} from "react";
import {Box, CircularProgress} from '@mui/material'
import UserForm from "../../components/Form";
import * as userApi from "../../api/modules/users";
import {IAddUserResponse} from "../../interfaces/users";

const CreateUser: FC = (): ReactElement => {
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const [createdAt, setCreatedAt] = useState<string>("")
    
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

            try {
                setIsLoading(true)
                const res: IAddUserResponse = await userApi.Add(data)
                
                setCreatedAt(res.createdAt)
                console.log(res);
            } catch (e) {
                if (e instanceof Error) {
                    console.error(e.message)
                }
            }
            setIsLoading(false)
    };
    
    return (
        <Box  
            sx={{
            flexGrow: 1,
            backgroundColor: "whitesmoke",
            display: "flex", 
            flexDirection: "column",    
            justifyContent: "center",
            alignItems: "center",
        }}>
            {isLoading ? (
                <CircularProgress />
            ) : ( <UserForm 
                title={"Add user"} 
                inputs={[{name: "name", label: "Name"}, {name: "job", label: "Job"}]} 
                buttonText={"Add"} 
                handleSubmit={handleSubmit} />)}
            {createdAt && "Created at " + createdAt}
        </Box>
    );
};

export default CreateUser;