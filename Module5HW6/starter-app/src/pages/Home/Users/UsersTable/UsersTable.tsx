import { Grid, CircularProgress } from '@mui/material';
import UserCard from '../UserCard';
import { IUser } from '../../../../interfaces/users';

interface UsersTableProps {
    isLoading: boolean;
    users: IUser[];
}

const UsersTable = ({ isLoading, users }: UsersTableProps) => {
    return (
        <Grid container spacing={4} justifyContent="center" my={4}>
            {isLoading ? (
                <CircularProgress />
            ) : (
                users.map((item) => (
                    <Grid key={item.id} item lg={2} md={3} xs={6}>
                        <UserCard {...item} />
                    </Grid>
                ))
            )}
        </Grid>
    );
};

export default UsersTable;
