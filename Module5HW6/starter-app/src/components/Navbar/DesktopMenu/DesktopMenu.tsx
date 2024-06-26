import { Box, Link } from '@mui/material';
import { NavLink } from 'react-router-dom';
import {observer} from "mobx-react-lite";
import {protectedRoutes} from "../../../protected-routes";
import {IAppStore} from "../../../interfaces/appStore";

interface MobileMenuProps {
    appStore: IAppStore;
    handleLogout: () => void;
}

const DesktopMenu = ({ appStore }: MobileMenuProps) => (
    <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
        <Box sx={{ display: 'flex', flexDirection: 'row', justifyContent: 'flex-start', alignItems: 'center', marginLeft: '1rem' }}>
            {appStore.authStore.token ? protectedRoutes.map(page => page.enabled && (
                <Link key={page.key} component={NavLink} to={page.path} color="black" underline="none" variant="button"
                      sx={{ fontSize: 'large', marginLeft: '2rem', transitionDuration: '300ms', '&:hover': { color: 'white' } }}>
                    {page.title}
                </Link>
            )) : null}
        </Box>
    </Box>
);

export default observer(DesktopMenu);
