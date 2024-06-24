export interface IUser {
    'id': number,
    'email': string,
    'first_name': string,
    'last_name': string,
    'avatar': string
}

export interface IAddUser {
    'name': string,
    'job': string,
}

export interface IAddUserResponse {
    'name': string,
    'job': string,
    'id': number,
    'createdAt': string
}

export interface IUpdateUserResponse {
    'name': string,
    'job': string,
    'id': number,
    'updatedAt': string
}