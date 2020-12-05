using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    public class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }

        public Passport()
        {
        }

        public static Passport CreateAndFillPassport(IPassportFiller filler)
        {
            return filler
                .FillBirthYear()
                .FillIssueYear()
                .FillExpirationYear()
                .FillHeight()
                .FillHairColor()
                .FillEyeColor()
                .FillPassportId()
                .FillCountryId()
                .Build();
        }

        public bool IsValid()
        {
            if (!string.IsNullOrEmpty(BirthYear) && !string.IsNullOrEmpty(IssueYear) && !string.IsNullOrEmpty(ExpirationYear) && !string.IsNullOrEmpty(Height)
            && !string.IsNullOrEmpty(HairColor) && !string.IsNullOrEmpty(EyeColor) && !string.IsNullOrEmpty(PassportID))
                return true;

            return false;
        }
    }
}