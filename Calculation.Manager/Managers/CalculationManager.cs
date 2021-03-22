using Calculation.Common.IManagers;
using Calculation.Common.ResponseModels;
using System;

namespace Calculation.Manager.Managers
{
    public class CalculationManager : ICalculationManager
    {
        static bool IsValidCountry(string country) => country == "at";
        static bool IsValidVatRate(int vatRate) => vatRate == 10 || vatRate == 13 || vatRate == 20;
        static bool IsValiddecimalInputMoneyAmount(decimal amount) => amount > 0;

        public DataResponceModel<VatCalculationResponce> GetAmmountCalculationFromGross(string country, int vatRate, decimal gross)
        {
            var responce = new DataResponceModel<VatCalculationResponce>();
            if (!IsValidCountry(country))
            {
                responce.Message = "Error in country.";
                return responce;
            }
            if (!IsValidVatRate(vatRate))
            {
                responce.Message = $"Error: this rate [{vatRate}] is not valid for Austria";
                return responce;
            }
            if (!IsValiddecimalInputMoneyAmount(gross))
            {
                responce.Message = $"Error: gross data is invalid";
                return responce;
            }
            responce.Model = new VatCalculationResponce()
            {
                Gross = gross,
                Net = Math.Round(gross * 100 / (100 + vatRate), 2),
                Vat = Math.Round(gross * vatRate / (100 + vatRate), 2),
                VatRate = vatRate
            };
            responce.Success = true;
            return responce;
        }

        public DataResponceModel<VatCalculationResponce> GetAmmountCalculationFromNetto(string country, int vatRate, decimal net)
        {
            var responce = new DataResponceModel<VatCalculationResponce>();
            if (!IsValidCountry(country))
            {
                responce.Message = "Error in country.";
                return responce;
            }
            if (!IsValidVatRate(vatRate))
            {
                responce.Message = $"Error: this rate [{vatRate}] is not valid for Austria";
                return responce;
            }
            if (!IsValiddecimalInputMoneyAmount(net))
            {
                responce.Message = $"Error: net data is invalid";
                return responce;
            }
            responce.Model = new VatCalculationResponce()
            {
                Gross = Math.Round((100 + vatRate) * net / 100, 2),
                Net = net,
                Vat = Math.Round(vatRate * net / 100, 2),
                VatRate = vatRate
            };
            responce.Success = true;
            return responce;
        }

        public DataResponceModel<VatCalculationResponce> GetAmmountCalculationFromVat(string country, int vatRate, decimal vat)
        {
            var responce = new DataResponceModel<VatCalculationResponce>();
            if (!IsValidCountry(country))
            {
                responce.Message = "Error in country.";
                return responce;
            }
            if (!IsValidVatRate(vatRate))
            {
                responce.Message = $"Error: this rate [{vatRate}] is not valid for Austria";
                return responce;
            }
            if (!IsValiddecimalInputMoneyAmount(vat))
            {
                responce.Message = $"Error: vat data is invalid";
                return responce;
            }

            responce.Model = new VatCalculationResponce()
            {
                Gross = Math.Round((100 + vatRate) * vat / vatRate, 2),
                Net = Math.Round(100 * vat / vatRate, 2),
                Vat = vat,
                VatRate = vatRate
            };
            responce.Success = true;
            return responce;
        }
    }
}
