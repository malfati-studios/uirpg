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
    
    

}
