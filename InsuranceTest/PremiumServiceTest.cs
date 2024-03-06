using InsuranceCore;
using InsuranceInfrastructure;

namespace InsuranceTest;

public class PremiumServiceTest
{
    private readonly IPremiumService _premiumService;

    public PremiumServiceTest()
    {
        _premiumService = new PremiumService();
    }

    [Fact]
    public void CalculateMonthlyPremium_Null_CalculatePremiumDTO()
    {
        // Arrange 
        CalculatePremiumDTO request = null;

        //Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            //Act
            _premiumService.CalculateMonthlyPremium(request);
        });
    }

    [Fact]
    public void CalculateMonthlyPremium_Null_Empty_Name()
    {
        // Arrange 
        CalculatePremiumDTO request = new()
        {
            Name = "",
            Occupation = ""
        };

        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            //Act
            _premiumService.CalculateMonthlyPremium(request);
        });
    }


    [Fact]
    public void CalculateMonthlyPremium_Null_Empty_Occupation()
    {
        // Arrange 
        CalculatePremiumDTO request = new()
        {
            Name = "",
            Occupation = ""
        };

        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            //Act
            _premiumService.CalculateMonthlyPremium(request);
        });
    }

    [Fact]
    public void CalculateMonthlyPremium_Age_Less_Than_One()
    {
        // Arrange 
        CalculatePremiumDTO request = new()
        {
            Name = "default",
            Occupation = "Doctor",
            Age = 0
        };

        //Assert
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            //Act
            _premiumService.CalculateMonthlyPremium(request);
        });

        Assert.Equal("Age should be greater than one", ex.Message);
    }

    [Fact]
    public void CalculateMonthlyPremium_Sum_Insured_Less_Than_One()
    {
        // Arrange 
        CalculatePremiumDTO request = new()
        {
            Name = "default",
            Occupation = "Doctor",
            Age = 23,
            SumInsured = 0
        };

        //Assert
        var ex = Assert.Throws<ArgumentException>(() =>
        {
            //Act
            _premiumService.CalculateMonthlyPremium(request);
        });

        Assert.Equal("Sum Insured should be greater than one", ex.Message);
    }

    [Fact]
    public void CalculateMonthlyPremium_Valid_Input()
    {
        // Arrange 
        CalculatePremiumDTO request = new()
        {
            Name = "default",
            Occupation = "Doctor",
            Age = 30,
            SumInsured = 100000
        };


        // formula
        // rating is 1.0
        // (30 * 100000 * 1.0) / 1000 * 12

        // Act
        double monthlyPremium = _premiumService.CalculateMonthlyPremium(request);

        // Assert
        Assert.Equal(36000, monthlyPremium);
    }
}