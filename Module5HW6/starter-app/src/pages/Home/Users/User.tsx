import React, { ReactElement, FC, useEffect, useState } from "react";
import { Box, CircularProgress, Grid } from '@mui/material';
import { useParams } from "react-router-dom";
import * as userApi from "../../../api/modules/users";
import { IUser } from "../../../interfaces/users";
import UserCard from "./UserCard";

const User: FC = (): ReactElement => {
    const [user, setUser] = useState<IUser | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const { id } = useParams();

    useEffect(() => {
        if (id) {
            const getUser = async () => {
                try {
                    setIsLoading(true);
                    const res = await userApi.getById(id);
                    setUser(res.data);
                } catch (e) {
                    if (e instanceof Error) {
                        console.error(e.message);
                    }
                }
                setIsLoading(false);
            };
            getUser();
        }
    }, [id]);

    return (
        <Box
            sx={{
                flexGrow: 1,
                backgroundColor: "whitesmoke",
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
            }}>
            <Grid container spacing={4} justifyContent="center" m={4}>
                {isLoading ? (
                    <CircularProgress />
                ) : (
                    user && (
                        <UserCard {...user} />
                    )
                )}
            </Grid>
        </Box>
    );
};

export default User;
