import React, {MouseEventHandler, ReactEventHandler} from 'react';
import { Box, IconButton, Menu, MenuItem, Typography, Link, Button } from '@mui/material';
import MenuIcon from '@mui/icons-material/Menu';
import { NavLink } from 'react-router-dom';
import {protectedRoutes} from "../../../protected-routes";
import {publicRoutes} from "../../../public-routes";
import {observer} from "mobx-react-lite";
import {IAppStore} from "../../../interfaces/appStore";

interface MobileMenuProps {
    anchorElNav: null | HTMLElement;
    handleOpenNavMenu: (e: React.MouseEvent<HTMLElement>) => void;
    handleCloseNavMenu: () => void;
    handleLogout: () => void;
    appStore: IAppStore;
}

const MobileMenu = ({ anchorElNav, handleOpenNavMenu, handleCloseNavMenu, handleLogout, appStore }: MobileMenuProps) => (
    <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
        <IconButton
            size="large"
            aria-label="account of current user"
            aria-controls="menu-appbar"
            aria-haspopup="true"
            onClick={handleOpenNavMenu}
            color="inherit"
        >
            <MenuIcon />
        </IconButton>
        <Menu
            id="menu-appbar"
            anchorEl={anchorElNav}
            anchorOrigin={{ vertical: 'bottom', horizontal: 'left' }}
            keepMounted
            transformOrigin={{ vertical: 'top', horizontal: 'left' }}
            open={Boolean(anchorElNav)}
            onClose={handleCloseNavMenu}
            sx={{ display: { xs: 'block', md: 'none' } }}
        >
            {!appStore.authStore.token ? publicRoutes.map(page => page.enabled && (
                <Link key={page.key} component={NavLink} to={page.path} color="black" underline="none" variant="button">
                    <MenuItem onClick={handleCloseNavMenu}>
                        <Typography textAlign="center">{page.title}</Typography>
                    </MenuItem>
                </Link>
            )) : (
                <>
                    {protectedRoutes.map(page => page.enabled && (
                        <Link key={page.key} component={NavLink} to={page.path} color="black" underline="none" variant="button">
                            <MenuItem onClick={handleCloseNavMenu}>
                                <Typography textAlign="center">{page.title}</Typography>
                            </MenuItem>
                        </Link>
                    ))}
                    <MenuItem onClick={handleCloseNavMenu}>
                        <Button sx={{ border: 1, backgroundColor: 'white', width: '100%' }} color="error" onClick={handleLogout}>Sign out</Button>
                    </MenuItem>
                </>
            )}
        </Menu>
    </Box>
);

export default observer(MobileMenu);
