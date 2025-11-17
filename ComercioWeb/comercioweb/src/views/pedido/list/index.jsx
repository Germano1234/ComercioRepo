import { useEffect, useState } from 'react';
import style from './_list.module.css';
import { excluir, pedidos as buscarPedidos } from '../../../services/pedido';
import { DataGrid } from '@mui/x-data-grid'
import { Box, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import ModalComponent from '../../../components/modal'
import { toast } from 'react-toastify';

function ListPedido () {
    const [pedidos, setPedidos] = useState([])
    const navigate = useNavigate()
    const [abrirModal, setAbrirModal] = useState(false)
    const [pedidoId, setPedidoId] = useState(null)

useEffect(() => {
    ObterPedido()
}, [])

const ObterPedido = async () => {
    const resposta = await buscarPedidos();
    setPedidos(resposta)
}
const columns = [
    {
        field: 'id',
        headerName: 'ID',
        flex: 0.5
    },
    {
        field: 'dataPedido',
        headerName: 'Data do Pedido',
        flex: 1
    },
    {
        field: 'cliente',
        headerName: 'Cliente',
        flex: 2
    },
    {
        field: 'action',
        headerName: 'Acao',
        headerAlign: 'center',
        flex: 0.9,
        renderCell: (params) => (
            <Box sx = {{display : 'flex', gap: 2, width: '100%', height: '100%', alignItems: 'center', justifyContent: 'center'}}>
                <Button
                    variant = 'contained'
                    onClick={() => handleEdit(params.row.id)}
                    >
                        Editar
                </Button>
                <Button
                    variant = 'contained'
                    color = 'error'
                    onClick={() => handleDelete(params.row.id)}
                    >
                        Deletar
                </Button>
            </Box>
        )
    }
]

    const handleEdit  = (id) => {
        navigate(`editar/${id}`)
    } 
    const handleDelete = (id) => {
        setAbrirModal(true);
        setPedidoId(id);

    }

    const excluirPedido = async () => {
        try 
        {
            await excluir(pedidoId)
            toast.success("Pedido Excluido com Sucesso")
            await ObterPedido()
            setAbrirModal(false)
        } catch (error) 
        {
            toast.error("Erro ao excluir o Pedido!")
        }
       
    }

    return (
        <div className={style.container}>
            <ModalComponent 
            open ={abrirModal} 
            close= {() => setAbrirModal(false)} 
            titulo={"Exclusao do Pedido"}
            descricao = {"Voce te certeza que deseja excluir este pedido?"}
            funcAceitar = {() => excluirPedido()}
            funcNegar={() => setAbrirModal(false)}/>
            <h2 className={style.title}>Lista de Produtos</h2>
            <div style = {{width:"100%"}}>
                <DataGrid
                    rows = {pedidos}
                    columns= {columns}
                    pageSize = {5}
                    rowsPerPageOptions = {[5,10,15]}
                    sx = {{
                        fontSize: "1rem"
                    }}
                />
            </div>
            <Box sx = {{width: '100%', display: 'flex', justifyContent: 'end', padding:'1rem 0 0 0'}}>
                <Button onClick = {() => navigate("cadastro")} variant='contained'>Cadastrar</Button>
            </Box>
        </div>
    )
}

export default ListPedido;