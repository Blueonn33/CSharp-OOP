namespace _01.Prototype.Models
{
    public class SandwichMenu
    {
        private readonly IDictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get
            {
                if (!sandwiches.ContainsKey(name))
                {
                    throw new ArgumentException($"Sandwich with name {name} does not exist.");
                }

                return sandwiches[name];
            }
            set
            {
                sandwiches.Add(name, value);
            }
        }
    }
}
