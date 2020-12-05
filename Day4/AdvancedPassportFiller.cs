using System.Text.RegularExpressions;

namespace Day4
{
    public class AdvancedPassportFiller : IPassportFiller
    {
        private string _rawInput;
        private Regex _birthYearRegex = new Regex(@"byr:(?<value>\d{4}) ");
        private Regex _issueYearRegex = new Regex(@"iyr:(?<value>\d{4}) ");
        private Regex _expirationYearRegex = new Regex(@"eyr:(?<value>\d{4}) ");
        private Regex _heightRegex = new Regex(@"hgt:(?<value>[^ ]*)");
        private Regex _hairColorRegex = new Regex(@"hcl:(?<value>#[a-f0-9]{6}) ");
        private Regex _eyeColorRegex = new Regex(@"ecl:(?<value>(amb|blu|brn|gry|grn|hzl|oth)) ");
        private Regex _passportIdRegex = new Regex(@"pid:(?<value>\d{9}) ");
        private Regex _countryIdRegex = new Regex(@"cid:(?<value>[^ ]*)");

        private Passport _passportToBuild = new Passport();

        public AdvancedPassportFiller(string input)
        {
            _rawInput = input.Replace('\n', ' ') + " ";
        }

        public IPassportFiller FillBirthYear()
        {
            var yearAsString = _birthYearRegex.Match(_rawInput).Groups["value"].Value;
            if (int.TryParse(yearAsString, out var year) && year >= 1920 && year <=2002)
            {
                _passportToBuild.BirthYear = yearAsString;
            }
            return this;

        }

        public IPassportFiller FillIssueYear()
        {
            var yearAsString = _issueYearRegex.Match(_rawInput).Groups["value"].Value;
            if (int.TryParse(yearAsString, out var year) && year >= 2010 && year <=2020)
            {
                _passportToBuild.IssueYear = yearAsString;
            }
            return this;
        }

        public IPassportFiller FillExpirationYear()
        {
            var yearAsString = _expirationYearRegex.Match(_rawInput).Groups["value"].Value;
            if (int.TryParse(yearAsString, out var year) && year >= 2020 && year <=2030)
            {
                _passportToBuild.ExpirationYear = yearAsString;
            }
            return this;
        }

        public IPassportFiller FillHeight()
        {
            var heightAsString = _heightRegex.Match(_rawInput).Groups["value"].Value;

            if (heightAsString.Contains("cm"))
            {
                var height = int.Parse(heightAsString.Substring(0, heightAsString.Length - 2));
                if (height >= 150 && height <= 193)
                    _passportToBuild.Height = heightAsString;
            }
            else if (heightAsString.Contains("in"))
            {
                var height = int.Parse(heightAsString.Substring(0, heightAsString.Length - 2));
                if (height >= 59 && height <= 76)
                    _passportToBuild.Height = heightAsString;
            }
            return this;
        }

        public IPassportFiller FillHairColor()
        {
            _passportToBuild.HairColor = _hairColorRegex.Match(_rawInput).Groups["value"].Value;
            return this;
        }

        public IPassportFiller FillEyeColor()
        {
            _passportToBuild.EyeColor = _eyeColorRegex.Match(_rawInput).Groups["value"].Value;
            return this;
        }

        public IPassportFiller FillPassportId()
        {
            _passportToBuild.PassportID = _passportIdRegex.Match(_rawInput).Groups["value"].Value;
            return this;
        }

        public IPassportFiller FillCountryId()
        {
            _passportToBuild.CountryID = _countryIdRegex.Match(_rawInput).Groups["value"].Value;
            return this;
        }

        public Passport Build() => _passportToBuild;
    }
}