using System.ComponentModel.DataAnnotations;

namespace InsuranceCore;

public class CalculatePremiumDTO
{
    public required string Name { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public int Age { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public double SumInsured { get; set; }
    public required string Occupation { get; set; }
}
