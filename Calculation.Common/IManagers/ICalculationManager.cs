using Calculation.Common.ResponseModels;

namespace Calculation.Common.IManagers
{
    public interface ICalculationManager
    {
        DataResponceModel<VatCalculationResponce> GetAmmountCalculationFromNetto(string country, int vatRate, decimal net);
        DataResponceModel<VatCalculationResponce> GetAmmountCalculationFromGross(string country, int vatRate, decimal gross);
        DataResponceModel<VatCalculationResponce> GetAmmountCalculationFromVat(string country, int vatRate, decimal vat);
    }
}
