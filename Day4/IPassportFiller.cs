namespace Day4
{
    public interface IPassportFiller
    {
        public IPassportFiller FillBirthYear();
        public IPassportFiller FillIssueYear();
        public IPassportFiller FillExpirationYear();
        public IPassportFiller FillHeight();
        public IPassportFiller FillHairColor();
        public IPassportFiller FillEyeColor();
        public IPassportFiller FillPassportId();
        public IPassportFiller FillCountryId();

        public Passport Build();
    }
}