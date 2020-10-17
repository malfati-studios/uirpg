using System.Collections.Generic;
using UnityEngine;

public class CharacterImageHandler : MonoBehaviour
{
    [SerializeField] private Dictionary<RaceInformation, Dictionary<ClassInformation, Sprite>> characterImages;
    [SerializeField] private Sprite[] elvesImages;

    public static CharacterImageHandler instance;
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void InitializeImageHandler(RaceInformation[] raceInfo, ClassInformation[] classInfo)
    {
        characterImages = new Dictionary<RaceInformation, Dictionary<ClassInformation, Sprite>>();
        foreach (RaceInformation r in raceInfo)
        {
            Dictionary<ClassInformation, Sprite> raceMap = new Dictionary<ClassInformation, Sprite>();
            foreach (ClassInformation c in classInfo)
            {
                if (c.name.Equals("Warrior"))
                {
                    raceMap.Add(c, elvesImages[0]);
                }

                if (c.name.Equals("Ranger"))
                {
                    raceMap.Add(c, elvesImages[1]);
                }

                if (c.name.Equals("Mage"))
                {
                    raceMap.Add(c, elvesImages[2]);
                }
            }

            characterImages.Add(r, raceMap);
        }
    }

    public Sprite GetCharacterImage(RaceInformation raceInfo, ClassInformation classInfo)
    {
        Dictionary<ClassInformation, Sprite> classImages = characterImages[raceInfo];
        return classImages[classInfo];
    }
}