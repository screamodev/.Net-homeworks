import React, {ReactElement, FC, useState} from "react";
import {Box, CircularProgress} from '@mui/material'
import {useParams} from "react-router-dom";
import * as userApi from "../../api/modules/users";
import {IUpdateUserResponse} from "../../interfaces/users";
import Form from "../../components/Form";

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
            ) : (<Form
                title={"Update user"} 
                inputs={[{name: "name", label: "Name", type: "text"}, {name: "job", label: "Job", type: "text"}]}
                buttonText={"Update"} 
                handleSubmit={handleSubmit} />
                )}
            {updatedAt && "Updated at " + updatedAt}
        </Box>
    );
};

export default UpdateUser;