using UnityEngine;

public class CombatController : MonoBehaviour
{
    private CombatController instance;

    void Awake()
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

    public void Attack()
    {
        Action enemyAction = EnemyController.DecideAction();
        if (enemyAction == Action.EVADE)
        {
            if (EnemyController.CalculateEvasion())
            {
                UIController.instance.UpdateCharacterLog(Action.ATTACK);
                UIController.instance.UpdateEnemyLog(Action.EVADE);
            }
            else
            {
                int playerDamage = CharacterController.instance.Attack();
                EnemyController.TakeDamage(playerDamage);
                UIController.instance.UpdateCharacterLog(Action.ATTACK, playerDamage);
                UIController.instance.UpdateEnemyLog(Action.EVADE, false);
            }
        }

        if (enemyAction == Action.HEAL)
        {
            int playerDamage = CharacterController.instance.Attack();
            bool died = EnemyController.TakeDamage(playerDamage);
            if (!died)
            {
                int healthRestored = EnemyController.Heal();
                UIController.instance.UpdateCharacterLog(Action.ATTACK, playerDamage);
                UIController.instance.UpdateEnemyLog(Action.HEAL, healthRestored);
            }
            else
            {
                UIController.instance.UpdateCharacterLog(Action.ATTACK, playerDamage);
                UIController.instance.UpdateEnemyLog(Action.DIE);
            }
        }

        if (enemyAction == Action.ATTACK)
        {
            int playerDamage = CharacterController.instance.Attack();
            EnemyController.TakeDamage(playerDamage);
            int enemyDamage = EnemyController.Attack();
            CharacterController.instance.TakeDamage(enemyDamage);
            UIController.instance.UpdateCharacterLog(Action.ATTACK, playerDamage);
            UIController.instance.UpdateEnemyLog(Action.ATTACK, enemyDamage);
        }
    }

    public void Heal()
    {
        Action enemyAction = EnemyController.DecideAction();
    }

    public void Evade()
    {
        Action enemyAction = EnemyController.DecideAction();
    }
}