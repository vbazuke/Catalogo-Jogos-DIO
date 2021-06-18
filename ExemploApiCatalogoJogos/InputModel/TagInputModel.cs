using System.ComponentModel.DataAnnotations;

namespace ExemploApiCatalogoJogos.InputModel
{
    public class TagInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da tag deve conter entre 2 e 15 caracteres")]
        public string Nome { get; set; }
    }
}
