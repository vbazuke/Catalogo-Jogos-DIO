using System;

namespace ExemploApiCatalogoJogos.Exceptions
{
    public class TagJaCadastradoException : Exception
    {
        public TagJaCadastradoException()
            : base("Este tag já está cadastrado")
        { }
    }
}
