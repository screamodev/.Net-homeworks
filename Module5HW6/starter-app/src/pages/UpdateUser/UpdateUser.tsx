import React, {ReactElement, FC, useState} from "react";
import {Box, CircularProgress} from '@mui/material'
import UserForm from "../../components/Form";
import * as userApi from "../../api/modules/users";
import {useParams} from "react-router-dom";
import {IUpdateUserResponse} from "../../interfaces/users";

const UpdateUser: FC = (): ReactElement => {
    const { id } = useParams()
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const [updatedAt, setUpdatedAt] = useState<string>("")

    
    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);

        if (id) {
        try {
            setIsLoading(true)
            const res: IUpdateUserResponse = await userApi.Update(+id, data)

            setUpdatedAt(res.updatedAt)
            console.log(res);
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message)
            }
        }
            setIsLoading(false)
        }
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
            ) : (<UserForm 
                title={"Update user"} 
                inputs={[{name: "name", label: "Name"}, {name: "job", label: "Job"}]} 
                buttonText={"Update"} 
                handleSubmit={handleSubmit} />
                )}
            {updatedAt && "Updated at " + updatedAt}
        </Box>
    );
};

export default UpdateUser;