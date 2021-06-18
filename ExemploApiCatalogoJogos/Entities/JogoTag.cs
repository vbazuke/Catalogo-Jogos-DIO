using System;

namespace ExemploApiCatalogoJogos.Entities
{
    public class JogoTag
    {
        public int Id { get; set; }
        public Guid IdJogo { get; set; }
        public Guid IdTag { get; set; }
    }
}
