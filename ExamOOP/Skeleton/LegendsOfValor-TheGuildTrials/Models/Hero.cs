using LegendsOfValor_TheGuildTrials.Models.Contracts;

public abstract class Hero : IHero
{
    public Hero(string name, string runeMark, int power, int mana, int stamina)
    {
        Name = name;
        RuneMark = runeMark;
        Power = power;
        Mana = mana;
        Stamina = stamina;
    }

    public string Name
    {
        get; private set;
    }
    public string RuneMark
    {
        get; private set;
    }
    public string GuildName
    {
        get; private set;
    }
    public int Power
    {
        get; set;
    }
    public int Mana
    {
        get; set;
    }
    public int Stamina
    {
        get; set;
    }

    public void JoinGuild(IGuild guild)
    {
        GuildName = guild.Name;
    }

    public abstract void Train();

    public string Essence()
    {
        return $"Essence Revealed - Power [{Power}] Mana [{Mana}] Stamina [{Stamina}]";
    }

    public override string ToString()
    {
        return $"Hero: [{Name}] of the Guild '{GuildName}' - RuneMark: {RuneMark}";
    }
}