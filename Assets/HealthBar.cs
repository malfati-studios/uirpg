using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fill = null;
    [SerializeField] private TextMeshProUGUI txtHealth = null;
    [SerializeField] private TextMeshProUGUI txtName = null;

    private int hpMax;
    
    public void InitHP(int hpMax)
    {
        this.hpMax = hpMax;
        txtHealth.text = hpMax.ToString() + "/" + hpMax.ToString();
    }

    public void UpdateCurrentHP(int currentHp)
    {
        txtHealth.text = currentHp.ToString() + "/" + hpMax.ToString();
        fill.fillAmount = (float) currentHp / (float) hpMax;
    }
}
