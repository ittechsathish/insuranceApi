using InsuranceCore;

namespace InsuranceInfrastructure;

public class PremiumService : IPremiumService
{
    public double CalculateMonthlyPremium(CalculatePremiumDTO calculatePremiumDTO)
    {
        ArgumentNullException.ThrowIfNull(calculatePremiumDTO);

        ArgumentException.ThrowIfNullOrEmpty(calculatePremiumDTO.Name);
        ArgumentException.ThrowIfNullOrEmpty(calculatePremiumDTO.Occupation);

        if (calculatePremiumDTO.Age < 1)
        {
            throw new ArgumentException("Age should be greater than one");
        }

        if (calculatePremiumDTO.SumInsured < 1)
        {
            throw new ArgumentException("Sum Insured should be greater than one");
        }

        double deathCoverAmount = calculatePremiumDTO.SumInsured;

        Rating rating = OccutaionData.OccupationRatingData.First(s => s.Occupation == calculatePremiumDTO.Occupation).Rating;
        double occupationRatingFactor = OccutaionData.RatingFactorData.First(s => s.Rating == rating).Factor;

        double deathPremiumMonthly = Math.Round(deathCoverAmount * occupationRatingFactor * calculatePremiumDTO.Age / 1000 * 12, 2);

        return deathPremiumMonthly;
    }
}
