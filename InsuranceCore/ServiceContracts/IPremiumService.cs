namespace InsuranceCore;

public interface IPremiumService
{
    double CalculateMonthlyPremium(CalculatePremiumDTO calculatePremiumDTO);
}

