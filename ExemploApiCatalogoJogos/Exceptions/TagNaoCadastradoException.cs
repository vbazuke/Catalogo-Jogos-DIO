using System;

namespace ExemploApiCatalogoJogos.Exceptions
{
    public class TagNaoCadastradoException: Exception
    {
        public TagNaoCadastradoException()
            :base("Este Tag não está cadastrado")
        {}
    }
}
