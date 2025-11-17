import { useEffect, useState } from 'react';
import style from './_list.module.css';
import { excluir, produtos as buscarProdutos } from '../../../services/produto';
import { DataGrid } from '@mui/x-data-grid'
import { Box, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import ModalComponent from '../../../components/modal'
import { toast } from 'react-toastify';

function ListProduto () {
    const [produtos, setProdutos] = useState([])
    const navigate = useNavigate()
    const [abrirModal, setAbrirModal] = useState(false)
    const [produtoId, setProdutoId] = useState(null)

useEffect(() => {
    ObterProduto()
}, [])

const ObterProduto = async () => {
    const resposta = await buscarProdutos();
    setProdutos(resposta)
}
const columns = [
    {
        field: 'id',
        headerName: 'ID',
        flex: 0.5
    },
    {
        field: 'nome',
        headerName: 'Nome',
        flex: 1
    },
    {
        field: 'descricao',
        headerName: 'Descricao',
        flex: 2
    },
    {
        field: 'valor',
        headerName: 'Valor',
        flex: 0.5,
        renderCell: (params) => `R$ ${params.row.valor}`
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
        setProdutoId(id);

    }

    const excluirProduto = async () => {
        try 
        {
            await excluir(produtoId)
            toast.success("Produto Excluido com Sucesso")
            await ObterProduto()
            setAbrirModal(false)
        } catch (error) 
        {
            toast.error("Erro ao excluir o Produto!")
        }
       
    }

    return (
        <div className={style.container}>
            <ModalComponent 
            open ={abrirModal} 
            close= {() => setAbrirModal(false)} 
            titulo={"Exclusao de Produto"}
            descricao = {"Voce te certez que deseja excluir este produto?"}
            funcAceitar = {() => excluirProduto()}
            funcNegar={() => setAbrirModal(false)}/>
            <h2 className={style.title}>Lista de Produtos</h2>
            <div style = {{width:"100%"}}>
                <DataGrid
                    rows = {produtos}
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

export default ListProduto;