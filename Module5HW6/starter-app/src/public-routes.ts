import Login from "./pages/Login";
import Register from "./pages/Register";
import NotFound from "./pages/NotFound";
import {Route} from "./interfaces/route";

export const publicRoutes: Array<Route> = [
    {
        key: 'login-route',
        title: 'Login',
        path: '/login',
        enabled: true,
        component: Login
    },
    {
        key: 'registration-route',
        title: 'Register',
        path: '/register',
        enabled: true,
        component: Register
    },
    {
        key: 'not-found',
        title: 'Register',
        path: '*',
        enabled: false,
        component: NotFound
    }
]