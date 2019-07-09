using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Key2Pokemons.Domain
{
    public sealed class PowerUp : ValueObject
    {
        private PowerUp(int value)
        {
            this.Value = value;
        }

        public static PowerUp None => new PowerUp(0);

        public static Result<PowerUp> Create(int value)
        {
            return Result.Create(value >= 0 && value <= 5, "").Map(() => new PowerUp(value));
        }

        public int Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}