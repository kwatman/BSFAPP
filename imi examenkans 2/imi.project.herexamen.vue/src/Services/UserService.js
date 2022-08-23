import axios from 'axios'

class UserService{

    getAll() {
        console.log(sessionStorage.getItem('token'))
        return axios.get('/api/users')
    }

    getById(id) {
        return axios.get(`/api/users/${id}`)
    }

    create(data) {
        return axios.post('/api/users', data)
    }

    update(id, data) {
        return axios.put(`/api/users/${id}`, data)
    }

    delete(id) {
        return axios.delete(`/users/${id}`)
    }
}

export default new UserService();