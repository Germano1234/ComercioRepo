import {Box, Button, Modal, Typography} from '@mui/material'

const ModalComponent = ({open, close, titulo, descricao, funcAceitar, funcNegar}) => {
    return (
        <Modal
            open={open}
            onClose={close}
            sx={{
                display: 'flex',
                alignItems: 'center',
                justifyContent: 'center'
            }}
        >
            <Box
                sx={{
                    display: "flex", 
                    alignItems: "center", 
                    flexDirection: 'column', 
                    backgroundColor: '#fff',
                    width: 'auto',
                    padding: 4,
                    borderRadius: '30px',
                    gap: 4
                }}
            >
                <Typography variant= 'h5'> {titulo}</Typography>
                <Typography>{descricao}</Typography>
                <Box
                    sx = {{ display: "flex", alignItems: "center", flexDirection: 'row', justifyContent: 'center', gap: 5}}
                >
                    <Button variant='contained' color='error' onClick = {funcNegar}>Cancelar</Button>
                    <Button variant = 'contained' onClick={funcAceitar}>Confirmar</Button>
                </Box>
            </Box>
        </Modal>
    )
}

export default ModalComponent;