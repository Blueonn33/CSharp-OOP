namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Sorcerer : Hero
    {
        public Sorcerer(string name, string runeMark) : base(name, runeMark, power: 40, mana: 120, stamina: 0)
        {

        }

        public override void Train()
        {
            Power += 20;
            Mana += 25;
        }
    }
}
