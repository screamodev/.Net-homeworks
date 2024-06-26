import apiClient from "../client";

export const getByPage = (page: number) => apiClient({
    path: `unknown?page=${page}`,
    method: 'GET'
})

export const getById = (id: number) => apiClient({
    path: `unknown/${id}`,
    method: 'GET'
})
