namespace ApiCaldeiras_MongoDB.Models.InputModels
{
    public class CaldeiraInputModel
    {
        public string NomeCaldeira { get; set; }
        public double Pressao { get; set; }
        public double NivelAgua { get;set; }
        public double NivelCombustivel { get; set; }
        public double Temperatura { get; set; }
    }
}
