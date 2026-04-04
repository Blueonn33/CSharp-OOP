namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Spellblade : Hero
    {
        public Spellblade(string name, string runeMark) : base(name, runeMark, power: 50, mana: 60, stamina: 60)
        {
        }

        public override void Train()
        {
            Power += 15;
            Mana += 10;
            Stamina += 10;
        }
    }
}
