import axios from 'axios';

export const pedidos = async () => {
    try
    {
        var response =  await axios.get("http://localhost:5091/api/Pedido");
        console.log(response?.data?.dado?.pedidos);
        return response?.data?.dado?.pedidos;
    }
    catch (error)
    {
        alert(error);
    }
}

export const cadastrar = async (pedido) => {
    try
    {
        var response =  await axios.post("http://localhost:5091/api/Pedido", pedido);
        console.log(response?.data?.dado?.pedidos);
        return response?.data?.dado?.pedidos;
    }
    catch (error)
    {
        alert(error);
    }
}

export const editar = async (id, pedido) => {
    try {
        const response = await axios.put(`http://localhost:5091/api/Pedido/${id}`, pedido);
        console.log(response);
        return response?.data?.dado;
    } catch (error) {
        console.log(error)
    }
}

export const pedido = async (id) => {
    try {
        var response = await axios.get(`http://localhost:5091/api/Pedido/${id}`);
        console.log(response?.data?.dado);
        return response?.data?.dado;
    } catch (error) {
        console.log(error);
    }
}

export const excluir = async (id) => {
    try {
        var response = await axios.delete(`http://localhost:5091/api/Pedido/${id}`);
        console.log(response?.data?.dado);
        return response?.data?.dado;
    } catch (error) {
        console.log(error);
    }
}