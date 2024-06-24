import React, {ReactElement, FC, useEffect, useState} from "react";
import {
    Box,
    Card,
    CardContent,
    CircularProgress,
    Grid,
    Typography
} from '@mui/material'
import * as resourceApi from "../../../api/modules/resources";
import {useNavigate, useParams} from "react-router-dom";
import {IResource} from "../../../interfaces/resources";

const ResourceCard: FC<any> = (): ReactElement => {
    const [resource, setResource] = useState<IResource | null>(null)
    const [isLoading, setIsLoading] = useState<boolean>(false)
    const { id } = useParams()
    const navigate = useNavigate()

    useEffect(() => {
        if (id) {
            const getResource = async () => {
                try {
                    setIsLoading(true)
                    const res = await resourceApi.getById(+id)
                    setResource(res.data)
                } catch (e) {
                    if (e instanceof Error) {
                        console.error(e.message)
                    }
                }
                setIsLoading(false)
            }
            getResource()
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
                            <CardContent>
                                <Typography noWrap gutterBottom variant="h6" component="div">
                                   Name: {resource?.name}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                   Year: {resource?.year}
                                </Typography>
                                <Typography variant="body2" color={resource?.color}>
                                   Color: {resource?.color}
                                </Typography>
                                <Typography variant="body2" color="text.secondary">
                                   Pantone value: {resource?.pantone_value}
                                </Typography>
                            </CardContent>
                        </Card>
                    </>
                )}
            </Grid>
        </Box>
    );
};

export default ResourceCard;