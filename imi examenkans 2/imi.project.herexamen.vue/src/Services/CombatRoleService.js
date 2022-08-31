import axios from 'axios'

class CombatRoleService{

    getAll() {
        return axios.get('/api/combatroles')
    }

    getById(id) {
        return axios.get(`/api/combatroles/${id}`)
    }

    create(data) {
        return axios.post('/api/combatroles', data)
    }

    update(id, data) {
        return axios.put(`/api/combatroles`, data)
    }

    delete(id) {
        return axios.delete(`api/combatroles/${id}`)
    }
}

export default new CombatRoleService();