import React, { FC } from 'react';
import {Grid, CircularProgress} from '@mui/material';
import { useNavigate } from 'react-router-dom';
import {observer} from "mobx-react-lite";
import { IResource } from '../../../../interfaces/resources';
import ResourceCard from "../ResourceCard";

interface ResourceGridProps {
    isLoading: boolean;
    resources: IResource[];
}

const ResourceGrid: FC<ResourceGridProps> = ({ isLoading, resources }) => {

    return (
        <Grid container spacing={4} justifyContent="center" my={4}>
            {isLoading ? (
                <CircularProgress />
            ) : (
                resources?.map((item) => (
                    <Grid key={item.id} item lg={2} md={3} xs={6}>
                        <ResourceCard {...item} />
                    </Grid>
                ))
            )}
        </Grid>
    );
};

export default observer(ResourceGrid);
