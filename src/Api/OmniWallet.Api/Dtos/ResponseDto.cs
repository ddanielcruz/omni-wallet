namespace OmniWallet.Api.Dtos
{
    /// <summary>
    /// DTO genérica de retorno de mensagens com código identificador.
    /// </summary>
    public class ResponseDto
    {
        public ResponseDto(string mensagem, int? codigo = null)
        {
            Mensagem = mensagem;
            Codigo = codigo;
        }

        public string Mensagem { get; }
        public int? Codigo { get; }
    }
}