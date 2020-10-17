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
    private int defense;
    private int attack;
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
   
}
