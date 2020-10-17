using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
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
        characterImage.sprite = CharacterController.instance.GetCharacterImage().sprite;
        characterHealthBar.InitName(CharacterController.instance.GetCharacterName());
    }

    [SerializeField] private HealthBar characterHealthBar;
    [SerializeField] private HealthBar enemyHealthBar;
    [SerializeField] private Image characterImage;
    [SerializeField] private Image enemyImage;
    [SerializeField] private Log combatLog;

    #region HP_METHODS
    
    public void InitCharacterHP(int hpMax)
    {
        characterHealthBar.InitHP(hpMax);
    }
    
    public void InitEnemyHP(int hpMax)
    {
        enemyHealthBar.InitHP(hpMax);
    }
    
    public void UpdateCharacterHP(int currentHp)
    {
        characterHealthBar.UpdateCurrentHP(currentHp);
    }
    
    public void UpdateEnemyHP(int currentHp)
    {
        enemyHealthBar.UpdateCurrentHP(currentHp);
    }
    
    #endregion
    
    #region IMAGE_METHODS

    public void UpdateCharacterImage(Image image)
    {
        characterImage = image;
    }
    
    public void UpdateEnemyImage(Image image)
    {
        enemyImage = image;
    }
    
    #endregion
    
    #region LOG_METHODS

    public void UpdateCharacterLog(Action action, int value)
    {
        combatLog.UpdateCharacterLog(action,value);
    }
    
    public void UpdateCharacterLog(Action action)
    {
        combatLog.UpdateCharacterLog(action);
    }
    
    public void UpdateCharacterLog(Action action, bool successful)
    {
        combatLog.UpdateCharacterLog(action, successful);
    }
    
    public void UpdateEnemyLog(Action action, int value)
    {
        combatLog.UpdateEnemyLog(action,value);
    }
    
    public void UpdateEnemyLog(Action action)
    {
        combatLog.UpdateEnemyLog(action);
    }
    
    public void UpdateEnemyLog(Action action, bool successful)
    {
        combatLog.UpdateEnemyLog(action, successful);
    }
    
    #endregion

}
