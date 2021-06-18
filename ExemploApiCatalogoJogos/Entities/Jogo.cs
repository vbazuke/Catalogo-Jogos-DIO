using System;
using System.Collections.Generic;

namespace ExemploApiCatalogoJogos.Entities
{
    public class Jogo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
        public string Imagem { get; set; }
        public List<String> Tags { get; set; }
    }
}
