using TMPro;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterTextLog;
    [SerializeField] private TextMeshProUGUI enemyTextLog;

    public void UpdateCharacterLog(Action action, int value)
    {
        switch (action)
        {
            case Action.ATTACK:
                characterTextLog.text = "You attacked for " + value + " damage.";
                break;
            case Action.HEAL:
                characterTextLog.text = "You restored " + value + " health.";
                break;
        }
    }

    public void UpdateCharacterLog(Action action)
    {
        switch (action)
        {
            case Action.ATTACK:
                characterTextLog.text = "You tried to attack.";
                break;
            case Action.EVADE:
                characterTextLog.text = "You evaded the attack.";
                break;
            case Action.DIE:
                characterTextLog.text = "You fucked up.";
                break;
        }
    }

    public void UpdateCharacterLog(Action action, bool successful)
    {
        switch (action)
        {
            case Action.EVADE:
                if (successful)
                {
                    characterTextLog.text = "You evaded the attack.";
                }
                else
                {
                    characterTextLog.text = "You failed to evade the attack.";
                }

                break;
        }
    }

    public void UpdateEnemyLog(Action action, int value)
    {
        switch (action)
        {
            case Action.ATTACK:
                enemyTextLog.text = "The enemy attacked you for " + value + " damage.";
                break;
            case Action.HEAL:
                enemyTextLog.text = "The enemy restored " + value + " health.";
                break;
        }
    }

    public void UpdateEnemyLog(Action action)
    {
        switch (action)
        {
            case Action.EVADE:
                enemyTextLog.text = "The enemy evaded the attack.";
                break;
            case Action.DIE:
                enemyTextLog.text = "You tea-bagged the enemy.";
                break;
        }
    }

    public void UpdateEnemyLog(Action action, bool successful)
    {
        switch (action)
        {
            case Action.EVADE:
                if (successful)
                {
                    enemyTextLog.text = "The enemy evaded the attack.";
                }
                else
                {
                    enemyTextLog.text = "The enemy failed to evade the attack.";
                }

                break;
        }
    }
}