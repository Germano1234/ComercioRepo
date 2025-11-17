import { Box, Button, Container, FormControl, FormHelperText, InputLabel, MenuItem, Select, TextField, Typography } from '@mui/material';
import { FieldArray, FormikContext, useFormik } from 'formik';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { cadastrar } from '../../../services/pedido';
import { toast } from 'react-toastify';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider'
import { DatePicker } from '@mui/x-date-pickers/DatePicker'
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'
import { produtos as buscarProdutos } from '../../../services/produto'
import { useEffect, useState } from 'react';

const CreatePedido = () => {
    const navigate = useNavigate();
    const [produtos, setProdutos] = useState([])

    const obterProduto = async () => {
        var resposta = await buscarProdutos();
        setProdutos(resposta)
    }

    const formik = useFormik({
        initialValues: {
            dataPedido: null,
            cliente: "",
            produtos: [
                {
                    id: "",
                    quantidade: ""
                }
            ]
        },
        validationSchema: Yup.object({
            dataPedido: Yup.date()
                .required("A data do pedido é obrigatória"),
            cliente: Yup.string()
                .required("O nome do cliente é obrigatório"),
            produtos: Yup.array().of(
                Yup.object().shape({
                    id: Yup.string()
                        .required("O produto é obrigatório"),
                    quantidade: Yup.number()
                        .typeError("A quantidade deve ser um número")
                        .required("A quantidade é obrigatória")
                        .min(1, "A quantidade minima é de 1 produto")
                })
            )
        }),
        onSubmit: async (values) => {
            try {
                const response = await cadastrar(values)
                toast.success("Pedido cadastrado com sucesso!")
                navigate("../pedidos")
            } catch (erro) {
                console.error(erro)
                toast.error("Erro ao cadastrar o Pedido!")
            }
        }
    })

    useEffect(() => {
        obterProduto()
    }, [])

    return (
        <LocalizationProvider dateAdapter={AdapterDayjs}>
            <Container sx={{ width: '100%', display: 'flex', alignItems: 'center', flexDirection: 'column', justifyContent: 'center', height: '100vh', gap: 5 }}>
                <Typography variant='h4'> Cadastro de Pedido</Typography>

                <FormikContext.Provider value={formik}>
                    <form onSubmit={formik.handleSubmit}>
                        <Box display="flex" flexDirection="column" gap={2} width={'30rem'}>
                            <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                                <TextField
                                    id="cliente"
                                    name="cliente"
                                    fullWidth
                                    label="Nome do Cliente"
                                    value={formik.values.cliente}
                                    onChange={formik.handleChange}
                                    error={formik.touched.cliente && Boolean(formik.errors.cliente)}
                                    helperText={formik.touched.cliente && formik.errors.cliente}
                                />
                            </Box>
                            <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                                <DatePicker
                                    label="Data do Pedido"
                                    value={formik.values.dataPedido}
                                    onChange={(value) => formik.setFieldValue('dataPedido', value)}
                                    slotProps={{
                                        textField: {
                                            fullWidth: true,
                                            error: Boolean(formik.touched.dataPedido && formik.errors.dataPedido),
                                            helperText: formik.touched.dataPedido && formik.errors.dataPedido
                                        }
                                    }}
                                />
                            </Box>
                            <FieldArray
                                name="produtos"
                                render={(arrayHelpers) => (
                                    <>
                                        {
                                            formik.values.produtos.map((produto, index) => (
                                                <Box key={index} display={'flex'} gap={1}>
                                                    <FormControl fullWidth error={formik.touched.produtos?.[index]?.id && Boolean(formik.errors.produtos?.[index]?.id)}>
                                                        <InputLabel id={`produto-label-${index}`}>Produtos</InputLabel>
                                                        <Select
                                                            labelId={`produto-label-${index}`}
                                                            name={`produtos[${index}].id`}
                                                            value={produto.id}
                                                            onChange={formik.handleChange}
                                                            label="Produtos"
                                                        >
                                                            {
                                                                produtos.map((item) => (
                                                                    <MenuItem key={item.id} value={item.id}>
                                                                        {item.nome}
                                                                    </MenuItem>
                                                                ))
                                                            }
                                                        </Select>
                                                        {formik.touched.produtos?.[index]?.id && formik.errors.produtos?.[index]?.id && (
                                                            <FormHelperText>
                                                                {formik.errors.produtos?.[index]?.id}
                                                            </FormHelperText>
                                                        )}
                                                    </FormControl>
                                                    <TextField
                                                        label={"Quantidade"}
                                                        name={`produtos[${index}].quantidade`}
                                                        type='number'
                                                        value={produto.quantidade}
                                                        onChange={formik.handleChange}
                                                        error={formik.touched.produtos?.[index]?.quantidade && Boolean(formik.errors.produtos?.[index]?.quantidade)}
                                                        helperText={formik.touched.produtos?.[index]?.quantidade && formik.errors.produtos?.[index]?.quantidade}
                                                    />

                                                    <Button sx={{width: '10rem'}} variant='outlined' color='error' onClick={() => arrayHelpers.remove(index)}>
                                                        Remover
                                                    </Button>
                                                </Box>
                                            ))
                                        }
                                        <Button variant='outlined' onClick={() => arrayHelpers.push({ id: "", quantidade: "" })}>
                                            Adicionar Produto
                                        </Button>
                                    </>
                                )}
                            />
                            <Box sx={{ display: 'flex', flexDirection: 'row', width: '100%', justifyContent: 'space-between', mt: 5 }}>
                                <Button variant="contained" sx={{ width: '10rem', backgroundColor: 'rgb(241, 224, 123)', color: '#000' }} onClick={() => navigate(-1)}>
                                    Voltar
                                </Button>
                                <Button variant="contained" sx={{ width: '10rem' }} color='primary' type='submit'>
                                    Cadastrar
                                </Button>
                            </Box>
                        </Box>
                    </form>
                </FormikContext.Provider>
            </Container>
        </LocalizationProvider>
    )
}

export default CreatePedido;
