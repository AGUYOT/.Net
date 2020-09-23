namespace ClientConvertisseurV1.Service.Implementation
{
    class ConvertService : IConvertService
    {
        public double Convert(int value, double taux)
        {
            return value * taux;
        }
    }
}
