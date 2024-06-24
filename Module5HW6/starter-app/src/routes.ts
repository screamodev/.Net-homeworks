// pages
import Home from "./pages/Home";
import About from "./pages/About";
import Products from "./pages/Products";
import User from "./pages/User";

// other
import {FC} from "react";
import CreateUser from "./pages/CreateUser/CreateUser";
import UpdateUser from "./pages/UpdateUser";
import ResourceCard from "./components/Resource/ResourceCard";

// interface
interface Route {
    key: string,
    title: string,
    path: string,
    enabled: boolean,
    component: FC<{}>
}

export const routes: Array<Route> = [
    {
        key: 'home-route',
        title: 'Home',
        path: '/',
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
        key: 'products-route',
        title: 'Products',
        path: '/products',
        enabled: true,
        component: Products
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
        enabled: true,
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
        key: 'product-route',
        title: 'Product',
        path: '/product/:id',
        enabled: false,
        component: ResourceCard
    },
]