using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    public bool puzzleCompleted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
