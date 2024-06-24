import React, {ReactElement, FC, useEffect, useState} from "react";
import {
    Box, Button,
    Card,
    CardContent,
    CardMedia,
    CircularProgress,
    Grid,
    Typography
} from '@mui/material'
import * as userApi from "../../api/modules/users"
import {IUser} from "../../interfaces/users";
import {useNavigate, useParams} from "react-router-dom";

const User: FC<any> = (): ReactElement => {
    const [user, setUser] = useState<IUser | null>(null)
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const { id } = useParams()
    const navigate = useNavigate()

    useEffect(() => {
        if (id) {
            const getUser = async () => {
                try {
                    setIsLoading(true)
                    const res = await userApi.getById(id)
                    setUser(res.data)
                } catch (e) {
                    if (e instanceof Error) {
                        console.error(e.message)
                    }
                }
                setIsLoading(false)
            }
            getUser()
        }
    }, [id])

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
                    <>
                        <Card sx={{ maxWidth: 250 }}>
                            <CardMedia
                                component="img"
                                height="250"
                                image={user?.avatar}
                                alt={user?.email}
                            />
                            <CardContent>
                                <Typography noWrap gutterBottom variant="h6" component="div">
                                    {user?.email}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                    {user?.first_name} {user?.last_name}
                                </Typography>
                            </CardContent>
                            <Box
                                display="flex"
                                justifyContent="center"
                            >
                                <Button onClick={() => navigate(`/update-user/${id}`)}>Edit</Button>
                                <Button color={"error"}>Delete</Button>
                            </Box>
                        </Card>
                    </>
                )}
            </Grid>
        </Box>
    );
};

export default User;