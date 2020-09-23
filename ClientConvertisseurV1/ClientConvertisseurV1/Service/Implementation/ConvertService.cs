namespace ClientConvertisseurV1.Service.Implementation
{
    class ConvertService : IConvertService
    {
        //Return true if the value can be converted, false eitherway
        public bool TryConvert(string valueTxt, double taux, out double result)
        {
            double value;
            if(!double.TryParse(valueTxt, out value))
            {
                result = 0;
                return false;
            }
            result = value * taux;
            return true;
        }
    }
}
