using System.ComponentModel.DataAnnotations;

namespace ExemploApiCatalogoJogos.InputModel
{
    public class JogoTagInputModel
    {
        [Required]
        public string idJogo { get; set; }
        [Required]
        public string idTag { get; set; }
    }
}
