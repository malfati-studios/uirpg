using UnityEngine;

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
        Sprite characterImage)
    {
        selectedCharacter = new Character(characterName, race, clazz, characterImage);
    }
}