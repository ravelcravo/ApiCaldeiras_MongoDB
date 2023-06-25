using ApiCaldeiras_MongoDB.Data.Configurations;
using ApiCaldeiras_MongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ApiCaldeiras_MongoDB.Data.Repositories
{
    public class CaldeirasRepository : ICaldeirasRepository
    {
        private readonly IMongoCollection<Caldeira> _caldeiras;

        public CaldeirasRepository(IDatabaseConfig databaseConfig)
        {
            var cliente = new MongoClient(databaseConfig.ConnectionString);
            var database = cliente.GetDatabase(databaseConfig.DatabaseName);

            _caldeiras = database.GetCollection<Caldeira>("caldeiras");
        }

        public void Adicionar(Caldeira caldeira)
        {
            _caldeiras.InsertOne(caldeira);
            
        }

        public void Atualizar(string id, Caldeira caldeiraAtualizada)
        {
            _caldeiras.ReplaceOne(caldeira => caldeira.Id == id, caldeiraAtualizada);
        }

        public IEnumerable<Caldeira> Buscar()
        {
            return _caldeiras.Find(caldeira => true).ToList();
        }

        public Caldeira Buscar(string id)
        {
            return _caldeiras.Find(caldeira => caldeira.Id == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _caldeiras.DeleteOne(caldeira => caldeira.Id == id);
        }
    }
}
