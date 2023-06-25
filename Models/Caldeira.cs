using System;

namespace ApiCaldeiras_MongoDB.Models
{
    public class Caldeira
    {
        public Caldeira(string _NomeCaldeira,string status, double pressao, double nivelAgua, double nivelCombustivel, double temperatura)
        {
            Id = Guid.NewGuid().ToString();
            NomeCaldeira = _NomeCaldeira;
            Status = status;
            Pressao = pressao;
            NivelAgua = nivelAgua;
            NivelCombustivel = nivelCombustivel;
            Temperatura = temperatura;
            Data = DateTime.Now;
        }

        public string Id { get; private set; }
        public string NomeCaldeira { get; private set; }
        public string Status { get; private set; }
        public double Pressao { get; private set; }
        public double NivelAgua { get; private set; }
        public double NivelCombustivel { get; private set; }
        public double Temperatura { get; private set; }

        public DateTime Data { get; private set; }

        public void AtualizarCaldeira(string status, double pressao, double nivelAgua, double nivelCombustivel, double temperatura)
        {
            Status = status;
            Pressao = pressao;
            NivelAgua = nivelAgua;
            NivelCombustivel = nivelCombustivel;
            Temperatura = temperatura;
            Data = DateTime.Now;
        }
    }
}
