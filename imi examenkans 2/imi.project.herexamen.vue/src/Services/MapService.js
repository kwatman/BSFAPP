import axios from 'axios'

class MapService{

    getAll() {
        console.log(sessionStorage.getItem('token'))
        return axios.get('/api/maps')
    }

    getById(id) {
        return axios.get(`/api/maps/${id}`)
    }

    create(data) {
        return axios.post('/api/maps', data)
    }

    delete(id) {
        return axios.delete(`/api/maps/${id}`)
    }
}

export default new MapService();