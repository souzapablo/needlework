namespace NeedleWork.UnitTests.Fakers;

public static class UserFaker
{
        public static User GenerateUser =>
        new Faker<User>("pt_BR")
            .RuleFor(x => x.Id, f => f.IndexFaker)
            .RuleFor(x => x.FirstName, f => f.Name.FirstName())
            .RuleFor(x => x.LastName, f => f.Name.LastName())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.BirthDate, GenerateDate())
            .Generate();
        
        private static DateOnly GenerateDate()
        {
            int day = Random.Shared.Next(1, 28);
            int month = Random.Shared.Next(1, 12);
            int year = Random.Shared.Next(1950, 2000);

            return new DateOnly(year, month, day);
        }
}