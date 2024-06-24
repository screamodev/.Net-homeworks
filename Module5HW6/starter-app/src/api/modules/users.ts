import apiClient from "../client";

export const getById = (id: string) => apiClient({
  path: `users/${id}`,
  method: 'GET'
})

export const getByPage = (page: number) => apiClient({
  path: `users?page=${page}`,
  method: 'GET'
})

export const Add = (userData: FormData) => apiClient({
  path: `users/`,
  method: 'POST',
  data: userData
})

export const Update = (id: number, userData: FormData) => apiClient({
  path: `users/${id}`,
  method: 'PUT',
  data: userData
})

export const Delete = (id: number) => apiClient({
  path: `users/${id}`,
  method: 'DELETE',
})