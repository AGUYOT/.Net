namespace ClientConvertisseurV2.Service.Implementation
{
    class ConvertService : IConvertService
    {
        public bool TryConvert(string valueTxt, double taux, out double result)
        {
            int value;
            if (!int.TryParse(valueTxt, out value))
            {
                result = 0;
                return false;
            }
            result = value * taux;
            return true;
        }
    }
}
