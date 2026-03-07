namespace Raiding
{
    public abstract class BaseAttackingHero : BaseHero
    {
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
