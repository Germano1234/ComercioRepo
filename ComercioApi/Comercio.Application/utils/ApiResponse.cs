namespace Comercio.Application.Utils
{
    public class ApiResponse<T> where T : class
    {
        public T? Dado {get; set;}
        public List<string>? Mensagens {get; set;}
        public bool Sucesso {get; set;}
        public ApiResponse(T data)
        {
            Dado = data;
            Sucesso = true;
        }

        public ApiResponse(List<string> mensagens)
        {
            Mensagens = mensagens;
            Sucesso = false;
        }
    }
}