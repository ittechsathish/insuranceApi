using InsuranceCore;

namespace InsuranceInfrastructure;

public class PremiumService : IPremiumService
{
    public double CalculateMonthlyPremium(CalculatePremiumDTO calculatePremiumDTO)
    {
        double deathCoverAmount = calculatePremiumDTO.SumInsured;

        Rating rating = OccutaionData.OccupationRatingData.First(s => s.Occupation == calculatePremiumDTO.Occupation).Rating;
        double occupationRatingFactor = OccutaionData.RatingFactorData.First(s => s.Rating == rating).Factor;

        double deathPremiumMonthly = deathCoverAmount * occupationRatingFactor * calculatePremiumDTO.Age / 1000 * 12;

        return deathPremiumMonthly;
    }
}
