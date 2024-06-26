import React, { ReactElement, FC, useEffect, useState } from "react";
import { Box, CircularProgress, Grid } from '@mui/material';
import { useParams } from "react-router-dom";
import * as resourceApi from "../../../api/modules/resources";
import { IResource } from "../../../interfaces/resources";
import ResourceCard from "./ResourceCard";

const Resource: FC = (): ReactElement => {
    const [resource, setResource] = useState<IResource | null>(null);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const { id } = useParams();

    useEffect(() => {
        if (id) {
            const getResource = async () => {
                try {
                    setIsLoading(true);
                    const res = await resourceApi.getById(+id);
                    setResource(res.data);
                } catch (e) {
                    if (e instanceof Error) {
                        console.error(e.message);
                    }
                }
                setIsLoading(false);
            };
            getResource();
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
                    resource && (
                        <ResourceCard {...resource} />
                    )
                )}
            </Grid>
        </Box>
    );
};

export default Resource;
