using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Character selectedCharacter;

    public static CharacterController instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetRaceAndClass(string characterName, RaceInformation race, ClassInformation clazz,
        Image characterImage)
    {
        selectedCharacter = new Character(characterName, race, clazz, characterImage);
    }

    public Image GetCharacterImage()
    {
        return selectedCharacter.GetCharacterImage();
    }
    
    public string GetCharacterName()
    {
        return selectedCharacter.GetCharacterName();
    }
}