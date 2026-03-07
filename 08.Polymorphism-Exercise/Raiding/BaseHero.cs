namespace Raiding
{
    public abstract class BaseHero : IHero
    {
        public string Name
        {
            get; init;
        }
        public int Power
        {
            get;
            init;
        }

        public abstract string CastAbility();
    }
}
