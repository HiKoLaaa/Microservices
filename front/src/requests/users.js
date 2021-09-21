import axios from "axios";

const BACKEND_BASE_URI = "http://localhost:4000/api/usr";

export const getUsers = async() => {
    const response = await axios.get(`${BACKEND_BASE_URI}/users`);
    return response.data;
}

export const deleteUser = async(accountId) => {
    const response = await axios.delete(`${BACKEND_BASE_URI}/users/accounts/${accountId}`);
    return response.data;
}

export const getUser = async(accountId) => {
    const response = await axios.get(`${BACKEND_BASE_URI}/users/accounts/${accountId}`);
    return response.data;
}

export const saveAccount = async(account) => {
    const response = await axios.post(`${BACKEND_BASE_URI}/accounts`, account);
    return response.data;
}

export const editAccount = async(account) => {
    const response = await axios.put(`${BACKEND_BASE_URI}/accounts`, account);
    return response.data;
}

export const saveProfile = async(profile) => {
    const response = await axios.post(`${BACKEND_BASE_URI}/profiles`, profile);
    return response.data;
}

export const editProfile = async(profile) => {
    const response = await axios.put(`${BACKEND_BASE_URI}/profiles`, profile);
    return response.data;
}

export const getDepartments = async() => {
    const response = await axios.get(`${BACKEND_BASE_URI}/profiles/departments`)
    return response.data;
}