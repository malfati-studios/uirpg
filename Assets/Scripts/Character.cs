using UnityEngine;
using UnityEngine.UI;

public class Character
{
    private string characterName;
    private RaceInformation race;
    private ClassInformation clazz;
    private Image characterImage;

    private int maxHp;
    private int currentHp;
    private int attack;
    private int defense;
    private int criticalChance;
    private int evasion;

    public Character(string characterName, RaceInformation race, ClassInformation clazz, Image characterImage)
    {
        this.characterName = characterName;
        this.race = race;
        this.clazz = clazz;
        this.characterImage = characterImage;
    }

    public Image GetCharacterImage()
    {
        return characterImage;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public int CalculateMaxHP()
    {
        maxHp = clazz.vitVal * StatConstants.HP_VITALITY_MULTIPLIER;
        currentHp = maxHp;
        return maxHp;
    }

    public int CalculateAttack()
    {
        int damage =
            clazz.baseDamage + clazz.strVal * StatConstants.ATTACK_STRENGTH_MULTIPLIER +
            clazz.intVal * StatConstants.ATTACK_INTELLIGENCE_MULTIPLIER +
            clazz.dexVal * StatConstants.ATTACK_DEXTERITY_MULTIPLIER;
        return CalculateCritChance() ? (int) (damage * StatConstants.CRIT_DAMAGE_MULTIPLIER) : damage;
    }

    public bool CalculateCritChance()
    {
        int randomValue = Random.Range(0, 10);
        double critThreshold = clazz.dexVal * StatConstants.CRIT_CHANCE_MULTIPLIER;
        return randomValue <= critThreshold;
    }

    public bool CalculateEvasion(bool triedEvade)
    {
        int randomValue = Random.Range(0, 10);
        double evadeThreshold = triedEvade
            ? clazz.dexVal * StatConstants.PLUS_EVASION_MULTIPLIER
            : clazz.dexVal * StatConstants.BASE_EVASION_MULTIPLIER;
        return randomValue <= evadeThreshold;
    }

    public int CalculateDefense()
    {
        return clazz.strVal * StatConstants.DEFENSE_STRENGTH_MULTIPLIER +
               clazz.vitVal * StatConstants.DEFENSE_VITALITY_MULTIPLIER;
    }
}