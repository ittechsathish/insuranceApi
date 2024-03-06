using InsuranceCore;

namespace InsuranceInfrastructure;

public static class OccutaionData
{
    public readonly static List<OccupationRating> OccupationRatingData =
    [
        new OccupationRating{
            Occupation = "Cleaner",
            Rating = Rating.Light_Manual,
        },
        new OccupationRating{
            Occupation = "Doctor",
            Rating = Rating.Professional,
        },
        new OccupationRating{
            Occupation = "Author",
            Rating = Rating.White_Collar,
        },
        new OccupationRating{
            Occupation = "Farmer",
            Rating = Rating.Heavy_Manual,
        },
        new OccupationRating{
            Occupation = "Mechanic",
            Rating = Rating.Heavy_Manual,
        },
        new OccupationRating{
            Occupation = "Florist",
            Rating = Rating.Light_Manual,
        },

    ];

    public readonly static List<RatingFactor> RatingFactorData = [
      new RatingFactor{
        Rating = Rating.Professional,
        Factor = 1.0
      },
      new RatingFactor{
        Rating = Rating.White_Collar,
        Factor = 1.25
      },
      new RatingFactor{
        Rating = Rating.Light_Manual,
        Factor = 1.50
      },
      new RatingFactor{
        Rating = Rating.Heavy_Manual,
        Factor = 1.75
      },
    ];
}

