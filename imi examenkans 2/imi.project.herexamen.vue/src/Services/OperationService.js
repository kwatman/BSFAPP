import axios from 'axios'

class OperationService{

    getAll() {
        console.log(sessionStorage.getItem('token'))
        return axios.get('/api/operations')
    }

    getById(id) {
        return axios.get(`/api/operations/${id}`)
    }

    create(data) {
        return axios.post('/api/operations', data)
    }

    update(id, data) {
        return axios.put(`/api/operations/${id}`, data)
    }

    delete(id) {
        return axios.delete(`/api/operations/${id}`)
    }
}

export default new OperationService();