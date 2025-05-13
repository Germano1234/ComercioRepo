namespace Comercio.Domain
{
    public class Pedido : Base{
        private DateTime _datapedido;
        private string _cliente;
        private List<PedidoProduto> _pedidosProdutos;
        public DateTime DataPedido
        {
            get {return _datapedido;}
            set {_datapedido = value;}
        }
        public string Cliente
        {
            get {return _cliente;}
            set {_cliente = value;}
        }
        public List<PedidoProduto> PedidosProdutos{
            get {return _pedidosProdutos;}
            set {_pedidosProdutos = value;}
        }

        public Pedido(){
            PedidosProdutos = new List<PedidoProduto>();
        }
    }
}