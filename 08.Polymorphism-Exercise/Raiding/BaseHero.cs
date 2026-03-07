namespace Raiding
{
    public abstract class BaseHero : IHero
    {
        public string Name
        {
            get; init;
        }
        public abstract int Power
        {
            get;
        }

        public abstract string CastAbility();
    }
}
