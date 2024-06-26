import React, { FC, ReactElement } from 'react';
import { Card, CardActionArea, CardContent, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { IResource } from '../../../../interfaces/resources';

const ResourceCard: FC<IResource> = (props): ReactElement => {
    const navigate = useNavigate();

    return (
        <Card sx={{ maxWidth: 250 }}>
            <CardActionArea onClick={() => navigate(`/resource/${props.id}`)}>
                <CardContent>
                    <Typography noWrap gutterBottom variant="h6" component="div">
                        Name: {props.name}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Year: {props.year}
                    </Typography>
                    <Typography variant="body2" color={props.color}>
                        Color: {props.color}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        Pantone value: {props.pantone_value}
                    </Typography>
                </CardContent>
            </CardActionArea>
        </Card>
    );
};

export default ResourceCard;
