using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionHandler : MonoBehaviour
{
    // Tag dari objek player (pastikan GameObject player di-tag dengan "Player")
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            ReloadScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(playerTag))
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
