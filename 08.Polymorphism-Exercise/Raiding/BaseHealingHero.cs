namespace Raiding
{
    public abstract class BaseHealingHero : BaseHero
    {
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}
