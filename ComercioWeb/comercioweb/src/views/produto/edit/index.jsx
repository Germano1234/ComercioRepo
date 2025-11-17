import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { editar, produto as getProduto} from "../../../services/produto"
import { useFormik } from "formik";
import * as Yup from 'yup';
import { toast } from "react-toastify";
import { Box, Button, Container, TextField, Typography } from "@mui/material";

const Edit = () => {
    const [produto, setProduto] = useState({})
    const info = useParams();
    const navigate = useNavigate();

    const formik = useFormik({
        enableReinitialize: true,
            initialValues:{
                nome: produto?.nome || "",
                descricao: produto?.descricao || "",
                valor: produto?.valor || ""
            },
            validationSchema: Yup.object({
                nome: Yup.string()
                    .required("O nome e obrigatorio")
                    .min(3, "Minimo de 3 caracteres"),
                descricao: Yup.string()
                    .required("A descricao e obrigatoria")
                    .min(10, "minimo de 10 caracteres"),
                valor: Yup.number()
                    .typeError("Deve ser um numero")
                    .required("O valor e obrigatorio")
                    .min(0, "O valor deve ser maior que 0")
            }),
            onSubmit: async (values) => {
                try{
                    const response = await editar(produto?.id, values)
                    toast.success("Produto editado com sucesso")
                    navigate("../Produtos")
                } catch (erro){
                    console.error(erro)
                    toast.error("Erro ao editar o Produto!")
                }
            }
        })

    useEffect(() => {
        obterProduto(info?.id)
    }, [info])

    const obterProduto = async (id) => {
        const response = await getProduto(id);
        setProduto(response)
    }

    return  (
        <Container sx = {{width: '100%', display: 'flex', alignItems: 'center', flexDirection: 'column', justifyContent: 'center', height: '100vh', gap: 5}}>
            <Typography variant='h4'>Editando Produto</Typography>

            <form onSubmit={formik.handleSubmit}>
                <Box display= 'flex' flexDirection="column" gap ={2} width = {'30rem'}>
                    <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                        <TextField
                        id="nome"
                        name="nome"
                        fullWidth
                        label = "Nome do Produto"
                        value = {formik.values.nome}
                        onChange={formik.handleChange}
                        error={formik.touched.nome && Boolean(formik.errors.nome)}
                        helperText = {formik.touched.nome && formik.errors.nome}
                        InputLabelProps = {{shrink: true}}
                    />
                    </Box>
                    <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                        <TextField
                        id="descricao"
                        name="descricao"
                        fullWidth
                        label = "Descricao do Produto"
                        value = {formik.values.descricao}
                        onChange={formik.handleChange}
                        error={formik.touched.descricao && Boolean(formik.errors.descricao)}
                        helperText = {formik.touched.descricao && formik.errors.descricao}
                        InputLabelProps = {{shrink: true}}
                    />
                    </Box>
                    <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                        <TextField
                        id="valor"
                        name="valor"
                        fullWidth
                        label = "Valor do Produto"
                        type = 'number'
                        value = {formik.values.valor}
                        onChange={formik.handleChange}
                        error={formik.touched.valor && Boolean(formik.errors.valor)}
                        helperText = {formik.touched.valor && formik.errors.valor}
                        InputLabelProps = {{shrink: true}}
                    />
                    </Box>
                    <Box sx={{ display: 'flex', flexDirection: 'row', width: '100%', justifyContent: 'space-between', mt: 5 }}>
                        <Button variant="contained" sx={{width: '10rem', backgroundColor:'rgb(241, 224, 123)', color: '#000'}} onClick={() => navigate(-1)}>
                            Voltar
                        </Button>
                        <Button variant="contained"sx={{width: '10rem'}} color='primary' type='submit'>
                            Editar
                        </Button>
                    </Box>
                </Box>
            </form>
        </Container>
    )
}

export default Edit;