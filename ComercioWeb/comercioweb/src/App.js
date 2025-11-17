import { Box, Button, Typography } from '@mui/material';
import style from './_app.module.css'
import ListProduto from './views/produto/list';
import Create from './views/produto/create';
import CreatePedido from './views/pedido/create';
import Edit from './views/produto/edit'
import  {Route, Routes, useNavigate} from 'react-router-dom'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import ListPedido from "./views/pedido/list"

function App() {
  const navigate = useNavigate();
  return (
    <div className={style.pagina}>
      <ToastContainer
      position = "top-center"
      autoClose={3000}
      hideProgressBar={true}
      closeOnClick
      pauseOnFocusLoss
      pauseOnHover
      theme = 'colored'
      draggable
      newestOnTop={false}
      />
      <Box
        sx = {{
          backgroundColor:'rgb(235, 237, 236)',
          width: '17%',
          height: '100vh',
          padding: 3,
          display: 'flex',
          flexDirection: 'column',
          gap: 3,
          boxShadow: '0 20px 10px rgba(14, 150 240, 0.5)'
        }}
      >
        <Typography variant = 'h3' sx = {{fontWeight: 'bold', width: '100%', textAlign: 'center'}}>Comercio</Typography>
        <Button onClick = {() => navigate("/produtos")} variant='contained' sx={{width: '100%', backgroundColor:'rgb(106, 164, 178)'}}>Produtos</Button>
        <Button onClick = {() => navigate("/pedidos")} variant='contained' sx={{width: '100%', backgroundColor:'rgb(106, 164, 179)'}}>Pedidos</Button>
      </Box>
      <Box
      sx = {{
          width: '83%',
          height: '100vh'
        }}
      >
          <Routes>
            <Route path="/produtos" element = {<ListProduto/>} />
            <Route path="/produtos/cadastro" element = {<Create/>} />
            <Route path="/produtos/editar/:id" element = {<Edit/>} />
            <Route path="/pedidos" element = {<ListPedido/>} />
            <Route path="/pedidos/cadastro" element = {<CreatePedido/>} />
          </Routes>
      </Box>
    </div>
  );
}

export default App;
