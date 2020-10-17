using UnityEngine;

public class Character
{
    private string characterName;
    private RaceInformation race;
    private ClassInformation clazz;
    private Sprite characterImage;

    private int maxHp;
    private int currentHp;
    private int defense;
    private int attack;
    private int criticalChance;
    private int evasion;
    
    public Character(string characterName, RaceInformation race, ClassInformation clazz, Sprite characterImage)
    {
        this.characterName = characterName;
        this.race = race;
        this.clazz = clazz;
        this.characterImage = characterImage;
    }
   
}
