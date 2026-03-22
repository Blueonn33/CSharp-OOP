namespace FakeAxeAndDummy.Tests
{
    public class FakeTarget : ITarget
    {
        public int Health
        {
            get; private set;
        }

        public FakeTarget(int health)
        {
            Health = health;
        }

        public int GiveExperience()
        {
            return 250;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {

        }
    }
}
