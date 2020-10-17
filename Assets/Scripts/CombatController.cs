using System;
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

    private void Start()
    {
        UIController.instance.InitCharacterHP(CharacterController.instance.GetCharacterMaxHP());
        UIController.instance.InitEnemyHP(EnemyController.instance.GetEnemyMaxHP());
    }

    public void Attack()
    {
        Action enemyAction = EnemyController.instance.DecideAction();
        if (enemyAction == Action.EVADE)
        {
            if (EnemyController.instance.CalculateEvasion())
            {
                UIController.instance.UpdateCharacterLog(Action.ATTACK);
                UIController.instance.UpdateEnemyLog(Action.EVADE);
            }
            else
            {
                int playerDamage = CharacterController.instance.Attack();
                EnemyController.instance.TakeDamage(playerDamage);
                UIController.instance.UpdateCharacterLog(Action.ATTACK, playerDamage);
                UIController.instance.UpdateEnemyLog(Action.EVADE, false);
            }
        }

        if (enemyAction == Action.HEAL)
        {
            int playerDamage = CharacterController.instance.Attack();
            bool died = EnemyController.instance.TakeDamage(playerDamage);
            if (!died)
            {
                int healthRestored = EnemyController.instance.Heal(StatConstants.POTION_HEALTH_RESTORE_AMOUNT);
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
            EnemyController.instance.TakeDamage(playerDamage);
            int enemyDamage = EnemyController.instance.Attack();
            CharacterController.instance.TakeDamage(enemyDamage);
            UIController.instance.UpdateCharacterLog(Action.ATTACK, playerDamage);
            UIController.instance.UpdateEnemyLog(Action.ATTACK, enemyDamage);
        }
    }

    public void Heal()
    {
        Action enemyAction = EnemyController.instance.DecideAction();
    }

    public void Evade()
    {
        Action enemyAction = EnemyController.instance.DecideAction();
    }
}