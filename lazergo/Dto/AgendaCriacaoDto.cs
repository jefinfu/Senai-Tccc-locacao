//a pasta DTO foi criada para ser um objetos de transferencias de dados como comunicação com o banco de dados
// DTO, sigla para Data Transfer Object (Objeto de Transferência de Dados), é um padrão de projeto de software utilizado para transferir dados entre diferentes camadas de uma aplicação.

namespace lazergo.Dto
{
    public class AgendaCriacaoDto
    {
        public string Nometerreno { get; set; } = string.Empty;
        public List<IFormFile> Fotos { get; set; } = new List<IFormFile>();
        public string Descricao { get; set; } = string.Empty;
        public double Valor { get; set; }

        public string EnderecoTer { get; set; } = string.Empty;
        public string NumeroTer { get; set; } = string.Empty;
        public string BairroTer { get; set; } = string.Empty;
        public string CidadeTer { get; set; } = string.Empty;
        public string CEPTer { get; set; } = string.Empty;
        public string UFTer { get; set; } = string.Empty;
        public string ProprietarioTer { get; set; } = string.Empty;
        public string CelularTer { get; set; } = string.Empty;
    }
}
