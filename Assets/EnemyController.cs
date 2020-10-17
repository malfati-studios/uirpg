using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
  
    [SerializeField] private Enemy currentEnemy;

    public static EnemyController instance;

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

    public Image GetEnemyImage()
    {
        return currentEnemy.GetCharacterImage();
    }
    
    public string GetEnemyName()
    {
        return currentEnemy.GetCharacterName();
    }

    public int Attack()
    {
        return currentEnemy.CalculateAttack();
    }

    public int Heal(int potionAmount)
    {
        return currentEnemy.CalculateHeal(potionAmount);
    }

    public bool Evade(bool triedEvade)
    {
        return currentEnemy.CalculateEvasion(triedEvade);
    }

    public bool TakeDamage(int damage)
    {
        return currentEnemy.TakeDamage(damage);
    }

    public bool CalculateEvasion()
    {
        throw new System.NotImplementedException();
    }

    public Action DecideAction()
    {
        throw new System.NotImplementedException();
    }
}
