using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

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

    public enum Scene
    {
        CHARACTER_CREATOR,
        COMBAT
    }

    public void LoadCombatScene()
    {
        SceneManager.LoadScene((int) Scene.COMBAT);
    }
}