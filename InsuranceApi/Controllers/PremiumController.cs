using InsuranceCore;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi;

public class PremiumController(IPremiumService _premiumService) : AppUserControllerBase
{
    [AcceptVerbs("POST")]
    [Route("calculate-monthly")]
    public async Task<IActionResult> CalculateMonthlyPremium(CalculatePremiumDTO calculatePremiumDTO)
    {
        double monthlyPremium = _premiumService.CalculateMonthlyPremium(calculatePremiumDTO);

        return Ok(monthlyPremium);
    }
}
