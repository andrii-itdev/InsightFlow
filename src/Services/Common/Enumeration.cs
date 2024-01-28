using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Infrastructure
{
    public record class Enumeration<T>
        where T : struct
    {
        public T Id { get; private set; }

        [NotNull]
        public string Name { get; private set; }

        protected Enumeration(T id, [NotNull] string name)
        {
            Id = id;
            Name = name;
        }

        public static IEnumerable<K> All<K>() 
            where K : Enumeration<T>
        {
            return typeof(K).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(x => x.GetValue(null))
                .Cast<K>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}