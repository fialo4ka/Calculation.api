namespace Calculation.Common.ResponseModels
{
    public class VatCalculationResponce
    {
        public int VatRate { get; set; }
        public decimal Net { get; set; }
        public decimal Gross { get; set; }
        public decimal Vat { get; set; }
    }
}
