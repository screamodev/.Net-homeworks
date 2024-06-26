import React, { ReactElement, FC } from "react";
import { Box, Button, Container, Pagination } from '@mui/material';
import { observer } from "mobx-react-lite";
import { useNavigate } from "react-router-dom";
import UsersTable from "./Users/UsersTable";  // Импортируем новый компонент
import HomeStore from "../../stores/HomeStore";

const store = new HomeStore();

const Home: FC<any> = (): ReactElement => {
    const navigate = useNavigate();

    return (
        <Box
            sx={{
                flexGrow: 1,
                backgroundColor: "whitesmoke",
                display: "flex",
                flexDirection: "column",
                justifyContent: "center",
                alignItems: "center",
            }}
        >
            <Container sx={{ display: "flex", justifyContent: "end", mt: 2 }} maxWidth={false}>
                <Button variant="outlined" onClick={() => navigate(`/create-user`)}>Add user</Button>
            </Container>
            <UsersTable isLoading={store.isLoading} users={store.users} />
            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center'
                }}
            >
                <Pagination count={store.totalPages} page={store.currentPage} onChange={async (event, page) => await store.changePage(page)} />
            </Box>
        </Box>
    );
};

export default observer(Home);
