import {Box, Button, Card, CardActionArea, CardContent, CardMedia, Typography} from "@mui/material"
import {FC, ReactElement} from "react";
import {IUser} from "../../../interfaces/users";
import {useNavigate} from "react-router-dom";
import * as userApi from "../../../api/modules/users";

const UserCard: FC<IUser> = (props): ReactElement => {

    const navigate = useNavigate()

    const handleDelete = async () => {
        try {
            const res = await userApi.Delete(props.id)
            console.log(res);
        } catch (e) {
            if (e instanceof Error) {
                console.error(e.message)
            }
        }
    }
    
     return (
        <Card sx={{ maxWidth: 250 }}>
            <CardActionArea onClick={() => navigate(`/user/${props.id}`)}>
                <CardMedia
                    component="img"
                    height="250"
                    image={props.avatar}
                    alt={props.email}
                />
                <CardContent>
                    <Typography noWrap gutterBottom variant="h6" component="div">
                        {props.email}
                    </Typography>
                    <Typography variant="body2" color="text.secondary">
                        {props.first_name} {props.last_name}
                    </Typography>
                </CardContent>
            </CardActionArea>
            <Box
                display="flex"
                justifyContent="center"
            >
                <Button onClick={() => navigate(`/update-user/${props.id}`)}>Edit</Button>
                <Button color={"error"} onClick={handleDelete}>Delete</Button>
            </Box>
        </Card>
    )
}

export default UserCard