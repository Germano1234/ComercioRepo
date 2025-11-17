import { Box, Button, Container, TextField, Typography } from '@mui/material';
import { useFormik } from 'formik';
import { useNavigate } from 'react-router-dom';
import * as Yup from 'yup';
import { cadastrar } from '../../../services/produto';
import { toast } from 'react-toastify';

const Create = () => {
    const navigate = useNavigate();

    const formik = useFormik({
        initialValues: {
            nome: '',
            descricao: '',
            valor: ''
        },
        validationSchema: Yup.object({
            nome: Yup.string()
                .required("O nome é obrigatório")
                .min(3, "Mínimo de 3 caracteres"),
            descricao: Yup.string()
                .required("A descrição é obrigatória")
                .min(10, "Mínimo de 10 caracteres"),
            valor: Yup.number()
                .typeError("Deve ser um número")
                .required("O valor é obrigatório")
                .min(0, "O valor deve ser maior que 0")
        }),
        onSubmit: async (values) => {
            try {
                const response = await cadastrar(values)
                toast.success("Produto cadastrado com sucesso!")
                navigate("../produtos")
            } catch (erro) {
                console.error(erro)
                toast.error("Erro ao cadastrar o Produto!")
            }
        }
    })

    return (
        <Container sx={{ width: '100%', display: 'flex', alignItems: 'center', flexDirection: 'column', justifyContent: 'center', height: '100vh', gap: 5 }}>
            <Typography variant='h4'> Cadastro de Produto</Typography>

            <form onSubmit={formik.handleSubmit}>
                <Box display="flex" flexDirection="column" gap={2} width={'30rem'}>
                    <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                        <TextField
                            id="nome"
                            name="nome"
                            fullWidth
                            label="Nome do Produto"
                            value={formik.values.nome}
                            onChange={formik.handleChange} // { (event) => setNome(event.target.values)}
                            error={formik.touched.nome && Boolean(formik.errors.nome)}
                            helperText={formik.touched.nome && formik.errors.nome}
                        />
                    </Box>
                    <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                        <TextField
                            id='descricao'
                            name='descricao'
                            fullWidth
                            label="Descrição do Produto"
                            value={formik.values.descricao}
                            onChange={formik.handleChange} // { (event) => setdescricao(event.target.values)}
                            error={formik.touched.descricao && Boolean(formik.errors.descricao)}
                            helperText={formik.touched.descricao && formik.errors.descricao}
                        />
                    </Box>
                    <Box sx={{ display: 'flex', width: '100%', height: '5rem' }}>
                        <TextField
                            id='valor'
                            name='valor'
                            fullWidth
                            label="Valor do Produto"
                            type='number'
                            value={formik.values.valor}
                            onChange={formik.handleChange} // { (event) => setvalor(event.target.values)}
                            error={formik.touched.valor && Boolean(formik.errors.valor)}
                            helperText={formik.touched.valor && formik.errors.valor}
                        />
                    </Box>
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
        </Container>
    )
}

export default Create;