import Home from "./pages/Home";
import About from "./pages/About";
import User from "./pages/Home/Users";
import CreateUser from "./pages/CreateUser/CreateUser";
import UpdateUser from "./pages/UpdateUser";
import {Route} from "./interfaces/route";
import Resources from "./pages/Resources";
import NotFound from "./pages/NotFound";
import ResourceCard from "./pages/Resources/Resource/ResourceCard";
import Resource from "./pages/Resources/Resource/Resource";

export const protectedRoutes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/home',
        enabled: true,
        component: Home
    },
    {
        key: 'about-route',
        title: 'About',
        path: '/about',
        enabled: true,
        component: About
    },
    {
        key: 'resources-route',
        title: 'Resources',
        path: '/resources',
        enabled: true,
        component: Resources
    },
    {
        key: 'user-route',
        title: 'User',
        path: '/user/:id',
        enabled: false,
        component: User
    },
    {
        key: 'create-user-route',
        title: 'Create user',
        path: '/create-user',
        enabled: false,
        component: CreateUser
    },
    {
        key: 'update-user-route',
        title: 'Update user',
        path: '/update-user/:id',
        enabled: false,
        component: UpdateUser
    },
    {
        key: 'resource-route',
        title: 'Resource',
        path: '/resource/:id',
        enabled: false,
        component: Resource
    },
    {
        key: 'not-found',
        title: 'Register',
        path: '*',
        enabled: false,
        component: NotFound
    }
]