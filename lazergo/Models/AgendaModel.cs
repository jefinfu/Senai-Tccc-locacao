//Aqui eu crio a Tabela AgendaModel do banco de dados. 

namespace lazergo.Models
{
    public class AgendaModel
    {
        public int Id { get; set; }
        public string Nometerreno { get; set; } = string.Empty;
        public string NomeImagem { get; set;} = string.Empty;
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
