import React, {FC, ReactNode, useContext, useEffect} from "react";
import { Box, CssBaseline } from "@mui/material";
import Navbar from "../Navbar";
import Footer from "../Footer";
import {useNavigate} from "react-router-dom";
import {AppStoreContext} from "../../App";

interface LayoutProps {
  children: ReactNode;
}

const Layout: FC<LayoutProps> = ({ children }) => {
    const appStore = useContext(AppStoreContext);
    const navigate = useNavigate()

    useEffect(() => {
        appStore.authStore.token ? navigate("/home") : navigate("/login")
    }, []);

  return (
    <>
      <CssBaseline />
      <Box
        sx={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "flex-start",
          minHeight: "100vh",
          maxWidth: "100vw",
          flexGrow: 1,
        }}
      >
        <Navbar />
        {children}
        <Footer />
      </Box>
    </>
  );
};

export default Layout;