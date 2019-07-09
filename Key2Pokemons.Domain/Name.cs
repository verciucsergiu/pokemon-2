using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Key2Pokemons.Domain
{
    public sealed class Name : ValueObject
    {
        private Name()
        {
        }

        public static Result<Name> Create(string name)
        {
            return Result.Create(name.Length >= 4 && name.Length <= 30, "Invalid name length")
                .Map(() => new Name() { Value = name });
        }

        public string Value { get; private set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Value;
        }
    }
}