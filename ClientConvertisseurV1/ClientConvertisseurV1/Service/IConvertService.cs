﻿namespace ClientConvertisseurV1.Service
{
    interface IConvertService
    {
        bool TryConvert(string value, double taux, out double result);
    }
}
