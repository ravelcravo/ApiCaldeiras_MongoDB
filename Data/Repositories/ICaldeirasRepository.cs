using ApiCaldeiras_MongoDB.Models;
using System.Collections;
using System.Collections.Generic;

namespace ApiCaldeiras_MongoDB.Data.Repositories
{
    public interface ICaldeirasRepository
    {
        void Adicionar(Caldeira caldeira);
        void Atualizar(string id, Caldeira caldeiraAtualizada);
        IEnumerable<Caldeira> Buscar();

        Caldeira Buscar(string id);

        void Remover(string id);
    }
}
