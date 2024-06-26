import React, {createContext, useContext} from "react";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { createTheme } from "@mui/material/styles";
import {BrowserRouter as Router, Routes, Route, useNavigate} from "react-router-dom";
import {observer} from "mobx-react-lite";
import { publicRoutes } from "./public-routes";
import { protectedRoutes } from "./protected-routes";
import Layout from "./components/Layout/Layout";
import AuthStore from "./stores/AuthStore";
import {IAppStore} from "./interfaces/appStore";

const store: IAppStore = {
  'authStore':  new AuthStore()
}
export const AppStoreContext = createContext(store);

function App() {
  const appStore = useContext(AppStoreContext);

  const theme = createTheme({
    palette: {
      primary: {
        light: "#63b8ff",
        main: "#2196f3",
        dark: "#005db0",
        contrastText: "#000",
      },
      secondary: {
        main: "#2196f3",
        light: "#82e9de",
        dark: "#00867d",
        contrastText: "#000",
      },
    },
  });

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        <Layout>
          <Routes>
            {appStore.authStore.token ? (protectedRoutes.map((route) => (
              <Route
                key={route.key}
                path={route.path}
                element={<route.component />}
              />
            )))
            : (publicRoutes.map((route) => (
                    <Route
                        key={route.key}
                        path={route.path}
                        element={<route.component />}
                    />
                )))}
          </Routes>
        </Layout>
      </Router>
    </ThemeProvider>
  );
}

export default observer(App);
