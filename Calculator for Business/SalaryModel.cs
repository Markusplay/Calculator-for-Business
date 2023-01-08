namespace Calculator_for_Business
{
    public class SalaryModel
    {
        public string? CompanyName { get; set; }
        public int? Percentage { get; set; }
        public double? Result { get; set; }
        public SalaryModel()
        {
            CompanyName = null;
            Percentage = null;
            Result = null;
        }
    }
}
