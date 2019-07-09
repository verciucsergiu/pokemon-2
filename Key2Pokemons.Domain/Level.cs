using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Key2Pokemons.Domain
{
    public sealed class Level : ValueObject
    {
        private Level(int level)
        {
            this.Value = level;
        }

        public static Level Zero => new Level(0);

        public Level NextLevel() => new Level(this.Value + 1);

        public int Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}