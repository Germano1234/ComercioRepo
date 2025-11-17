import axios from 'axios';

export const produtos = async () => {
    try
    {
        var response =  await axios.get("http://localhost:5091/api/Produto");
        console.log(response?.data?.dado?.produtos);
        return response?.data?.dado?.produtos;
    }
    catch (error)
    {
        alert(error);
    }
}

export const cadastrar = async (produto) => {
    try
    {
        var response =  await axios.post("http://localhost:5091/api/Produto", produto);
        console.log(response?.data?.dado?.produtos);
        return response?.data?.dado?.produtos;
    }
    catch (error)
    {
        alert(error);
    }
}

export const editar = async (id, produto) => {
    try {
        const response = await axios.put(`http://localhost:5091/api/Produto/${id}`, produto);
        console.log(response);
        return response?.data?.dado;
    } catch (error) {
        console.log(error)
    }
}

export const produto = async (id) => {
    try {
        var response = await axios.get(`http://localhost:5091/api/Produto/${id}`);
        console.log(response?.data?.dado);
        return response?.data?.dado;
    } catch (error) {
        console.log(error);
    }
}

export const excluir = async (id) => {
    try {
        var response = await axios.delete(`http://localhost:5091/api/Produto/${id}`);
        console.log(response?.data?.dado);
        return response?.data?.dado;
    } catch (error) {
        console.log(error);
    }
}