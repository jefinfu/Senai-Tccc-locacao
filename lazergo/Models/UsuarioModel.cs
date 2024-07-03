using System.ComponentModel.DataAnnotations;

namespace lazergo.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        //verificar esse Datetime se nao vai dar problema com o mysql.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DtNascimento { get; set; }

        public string Celular { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Observacao { get; set; }
        public string TipoPessoa { get; set; }
        public string TipoUsuario { get; set; }


    }
}
