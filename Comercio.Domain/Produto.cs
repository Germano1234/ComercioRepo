using System.Dynamic;

namespace Comercio.Domain
{
    public class Produto : Base
    {
        #region Atributos
        private string _nome;
        private string _descricao;
        private decimal _valor;
        private List<PedidoProduto> _pedidosProdutos;
        #endregion

        #region Propriedades

        public string Nome{
            get {return _descricao;}
            set {_nome = value;}
        }

        public string Descicao{
            get {return _descricao;}
            set {_descricao = value;}
        }


        public decimal Valor{
            get{return _valor;}
            set{_valor = value;}
        }

        public List<PedidoProduto> PedidosProdutos{
            get {return _pedidosProdutos;}
            set {_pedidosProdutos = value;}
        }
        #endregion
        #region Construtores
        public Produto()
        {
            PedidosProdutos = new List<PedidoProduto>();
        }
        #endregion
    }
}