using System.Text.RegularExpressions;

namespace Day4
{
    public class BasicPassportFiller : IPassportFiller
    {
        private string _rawInput;
        private Regex _birthYearRegex = new Regex(@"byr:(?<value>[^ ]*)");
        private Regex _issueYearRegex = new Regex(@"iyr:(?<value>[^ ]*)");
        private Regex _expirationYearRegex = new Regex(@"eyr:(?<value>[^ ]*)");
        private Regex _heightRegex = new Regex(@"hgt:(?<value>[^ ]*)");
        private Regex _hairColorRegex = new Regex(@"hcl:(?<value>[^ ]*)");
        private Regex _eyeColorRegex = new Regex(@"ecl:(?<value>[^ ]*)");
        private Regex _passportIdRegex = new Regex(@"pid:(?<value>[^ ]*)");
        private Regex _countryIdRegex = new Regex(@"cid:(?<value>[^ ]*)");
        
        private Passport _passportToBuild = new Passport();
        public BasicPassportFiller(string input)
        {
            _rawInput = input.Replace('\n', ' ') + " ";
        }

        public IPassportFiller FillBirthYear()
        {
            _passportToBuild.BirthYear = _birthYearRegex.Match(_rawInput).Groups["value"].Value;
            return this;
        }

        public IPassportFiller FillIssueYear()
        {
            _passportToBuild.IssueYear = _issueYearRegex.Match(_rawInput).Groups["value"].Value;
            return this;
        }

        public IPassportFiller FillExpirationYear()
        {
            _passportToBuild.ExpirationYear = _expirationYearRegex.Match(_rawInput).Groups["value"].Value;
            return this;
        }

        public IPassportFiller FillHeight()
        {
            _passportToBuild.Height = _heightRegex.Match(_rawInput).Groups["value"].Value;
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