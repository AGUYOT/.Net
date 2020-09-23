namespace ClientConvertisseurV2.Service
{
    public interface IConvertService
    {
        bool TryConvert(string value, double taux, out double result);
    }
}
