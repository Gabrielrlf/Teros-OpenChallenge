import axios from 'axios';

class RequestBase {
    client: any;

    constructor(baseURL : any) {
        this.client = axios.create({
            baseURL,
        });
    }

    // Método para configurações globais, como headers comuns
    setCommonHeaders(headers : any) {
        this.client.defaults.headers.common = { ...this.client.defaults.headers.common, ...headers };
    }

    // Método para fazer uma requisição GET
    async get(url: string, params = {}) {
        try {
            console.log(url, 'url')
            const response = await this.client.get(url, { params });
            return response.data;
        } catch (error) {
            throw error;
        }
    }

    // Método para fazer uma requisição POST
    async post(url: string, data = {}, config = {}) {
        try {
            const response = await this.client.post(url, data, config);
            return response.data;
        } catch (error) {
            throw error;
        }
    }

    // Método para fazer uma requisição PUT
    async put(url: string, data = {}, config = {}) {
        try {
            const response = await this.client.put(url, data, config);
            return response.data;
        } catch (error) {
            throw error;
        }
    }

    // Método para fazer uma requisição DELETE
    async delete(url: string, config = {}) {
        try {
            const response = await this.client.delete(url, config);
            return response.data;
        } catch (error) {
            throw error;
        }
    }
}

export default RequestBase;