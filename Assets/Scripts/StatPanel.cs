using TMPro;
using UnityEngine;

public class StatPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI strText;
    [SerializeField] private TextMeshProUGUI dexText;
    [SerializeField] private TextMeshProUGUI intText;
    [SerializeField] private TextMeshProUGUI vitText;

    public void FillStats(int strText, int dexText, int intText, int vitText)
    {
        this.strText.text = strText.ToString();
        this.dexText.text = dexText.ToString();
        this.intText.text = intText.ToString();
        this.vitText.text = vitText.ToString();
    }
}
