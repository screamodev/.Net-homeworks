import { Container, Button, Link } from '@mui/material';
import { NavLink } from 'react-router-dom';
import {observer} from "mobx-react-lite";
import {publicRoutes} from "../../../public-routes";
import {IAppStore} from "../../../interfaces/appStore";

interface AuthButtonsProps {
    appStore: IAppStore;
    handleLogout: () => void;
}

const AuthButtons = ({ appStore, handleLogout }: AuthButtonsProps) => (
    <Container sx={{ justifyContent: 'end', alignItems: "center", display: { xs: 'none', md: 'flex' } }} maxWidth="xs">
        {!appStore.authStore.token ? publicRoutes.map(page => page.enabled && (
            <Link key={page.key} component={NavLink} to={page.path}>
                <Button sx={{ m: 0.5, backgroundColor: 'white', color: 'black', borderColor: 'black' }} size="medium" variant="outlined">{page.title}</Button>
            </Link>
        )) : (
            <Button sx={{ m: 0.5, backgroundColor: 'white' }} size="medium" variant="outlined" color="error" onClick={handleLogout}>Sign out</Button>
        )}
    </Container>
);

export default observer(AuthButtons);
