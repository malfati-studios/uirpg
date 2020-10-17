using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private string enemyName;
    private Image enemyImage;

    [SerializeField] private int maxHp = 1000;
    [SerializeField] private int currentHp = 1000;
    [SerializeField] private int attack = 15;
    [SerializeField] private int defense = 5;

    public Enemy(string enemyName, Image enemyImage)
    {
        this.enemyName = enemyName;
        this.enemyImage = enemyImage;
    }

    public Image GetCharacterImage()
    {
        return enemyImage;
    }

    public string GetCharacterName()
    {
        return enemyName;
    }

    public int CalculateMaxHP()
    {
        return maxHp;
    }

    public int CalculateAttack()
    {
        return attack;
    }

    public bool CalculateCritChance()
    {
        return false;
    }

    public bool CalculateEvasion(bool triedEvade)
    {
        return false;
    }

    public int CalculateDefense()
    {
        return defense;
    }

    public int CalculateHeal(int potionAmount)
    {
        return potionAmount;
    }

    public bool TakeDamage(int damage)
    {
        if (damage - defense > 0)
        {
            currentHp -= damage - defense;
        }

        return currentHp < 1;
    }

    public static Action DecideAction()
    {
        return (Action) Random.Range(0, 4);
    }
}