import React, { FC, ReactElement, useContext } from 'react';
import { Box, Container, Toolbar, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import { AppStoreContext } from '../../App';
import { observer } from 'mobx-react-lite';
import MobileMenu from './MobileMenu';
import DesktopMenu from './DesktopMenu';
import AuthButtons from './AuthButtons';

const Navbar: FC = (): ReactElement => {
    const appStore = useContext(AppStoreContext);
    const [anchorElNav, setAnchorElNav] = React.useState(null);
    const navigate = useNavigate();

    const handleOpenNavMenu = (event: any) => {
        setAnchorElNav(event.currentTarget);
    };

    const handleCloseNavMenu = () => {
        setAnchorElNav(null);
    };

    const handleLogout = () => {
        appStore.authStore.logout();
        navigate(`/login`);
    };

    return (
        <Box sx={{ width: '100%', height: 'auto', backgroundColor: 'secondary.main', display: 'flex' }}>
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Typography variant="h6" noWrap sx={{ mr: 2, display: { xs: 'none', md: 'flex' } }}>
                        A-LEVEL CURSE
                    </Typography>
                    <MobileMenu
                        anchorElNav={anchorElNav}
                        handleOpenNavMenu={handleOpenNavMenu}
                        handleCloseNavMenu={handleCloseNavMenu}
                        handleLogout={handleLogout}
                        appStore={appStore}
                    />
                    <Typography variant="h6" noWrap component="div" sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
                        A-LEVEL COURSE
                    </Typography>
                    <DesktopMenu
                        appStore={appStore}
                        handleLogout={handleLogout}
                    />
                </Toolbar>
            </Container>
            <AuthButtons appStore={appStore} handleLogout={handleLogout} />
        </Box>
    );
};

export default observer(Navbar);
