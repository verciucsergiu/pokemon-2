using CSharpFunctionalExtensions;

namespace Key2Pokemons.Domain
{
    public sealed class Trainer : Entity
    {
        private Trainer(Name name, string email)
        {
            Name = name;
            Email = email;

            Level = Level.Zero;
            PowerUp = PowerUp.None;
        }

        public static Result<Trainer> Create(string name, string email)
        {
            return Name.Create(name).Map(x => new Trainer(x, email));
        }
        
        public Name Name { get; private set; }

        public Level Level { get; private set; }

        public PowerUp PowerUp { get; private set; }

        public string Email { get; private set; }

        public void LevelUp()
        {
            Level = Level.NextLevel();
        }

        public Result AddPowerUp(int powerValue)
        {
            var invariantResult =
                Result.Create(Level.Value > 4, "Trainer must be at least level 5 to have a power up!");
            var powerUpResult = PowerUp.Create(powerValue);

            return Result.Combine(invariantResult, powerUpResult)
                .OnSuccess(() => PowerUp = powerUpResult.Value);
        }

        public Result ChangePersonalInfo(string name, string email)
        {
            return Name.Create(name)
                .OnSuccess(x => ChangeInfo(x, email));
        }

        private void ChangeInfo(Name name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}