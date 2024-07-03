using System.ComponentModel.DataAnnotations;

namespace lazergo.Dto
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "Insira um usuário!")]
        public string Usuario {  get; set; }
        [Required(ErrorMessage = "Insira um Email!")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Insira uma Senha!")]
        public string Senha { get; set;}
        [Required(ErrorMessage = "Insira a confirmação da Senha"), Compare("Senha", ErrorMessage = "Senhas estão diferentes!")]
        public string ConfirmaSenha { get; set;}

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }

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
    public class DataNascimentoValidation
    {
        public static ValidationResult ValidateAge(DateTime DtNascimento, ValidationContext context)
        {
            var age = DateTime.Today.Year - DtNascimento.Year;
            if (DtNascimento > DateTime.Today.AddYears(-age)) age--;
            return age >= 18 ? ValidationResult.Success : new ValidationResult("Cliente deve ser maior de 18 anos.");
        }
    }
}
