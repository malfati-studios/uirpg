using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CharacterCreator : MonoBehaviour
{
    #region GlobalData

    [Header("Global Data")] [SerializeField]
    private RaceInformation[] availableRaces;

    [SerializeField] private ClassInformation[] availableClasses;
    [SerializeField] private StatPanel statPanel;
    [SerializeField] private TextMeshProUGUI racePickerText;
    [SerializeField] private TextMeshProUGUI classPickerText;
    [SerializeField] private TextMeshProUGUI backgroundText;
    [SerializeField] private TMP_InputField inputName;

    #endregion

    public static CharacterCreator instance;

    #region CurrentData

    [Header("Current Data")] [SerializeField]
    private RaceInformation raceInfo;

    [SerializeField] private ClassInformation classInfo;
    [SerializeField] private GameObject characterImage;
    private int raceIndex = 0;
    private int classIndex = 0;

    #endregion

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

    private void Start()
    {
        CharacterImageHandler.instance.InitializeImageHandler(availableRaces, availableClasses);
        FillDefaultUI();
        RefreshUI();
    }

    private void FillDefaultUI()
    {
        if (availableRaces.Length > 0)
        {
            raceInfo = availableRaces[raceIndex];
        }

        if (availableClasses.Length > 0)
        {
            classInfo = availableClasses[classIndex];
        }
    }

    private void RefreshUI()
    {
        RefreshImage();
        RefreshDetailsText();
        RefreshStats();
    }

    private void RefreshImage()
    {
        Sprite charSprite = CharacterImageHandler.instance.GetCharacterImage(raceInfo, classInfo);
        characterImage.GetComponent<Image>().sprite = charSprite;
    }

    private void RefreshDetailsText()
    {
        racePickerText.text = raceInfo.name;
        backgroundText.text = raceInfo.raceBackground;
        classPickerText.text = classInfo.name;
    }

    private void RefreshStats()
    {
        statPanel.FillStats(classInfo.strVal, classInfo.dexVal, classInfo.intVal, classInfo.vitVal);
    }

    public void OnRightRaceButtonPress()
    {
        raceIndex++;
        raceIndex = raceIndex % availableRaces.Length;
        raceInfo = availableRaces[raceIndex];
        RefreshUI();
    }

    public void OnLeftRaceButtonPress()
    {
        if (raceIndex > 1)
        {
            raceIndex--;
        }
        else
        {
            raceIndex = availableRaces.Length - 1;
        }

        raceInfo = availableRaces[raceIndex];
        RefreshUI();
    }

    public void OnRightClassButtonPress()
    {
        classIndex++;
        classIndex = classIndex % availableClasses.Length;
        classInfo = availableClasses[classIndex];
        RefreshUI();
    }

    public void OnLeftClassButtonPress()
    {
        if (classIndex > 0)
        {
            classIndex--;
        }
        else
        {
            classIndex = availableClasses.Length - 1;
        }

        classInfo = availableClasses[classIndex];
        RefreshUI();
    }

    public void ConfirmCharacter()
    {
        CharacterController.instance.SetRaceAndClass(inputName.text, raceInfo, classInfo,
            characterImage.GetComponent<Image>().sprite);
        SceneController.instance.LoadCombatScene();
    }
}