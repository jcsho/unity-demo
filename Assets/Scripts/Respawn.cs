using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    public PlayerController player;
    public Transform respawnPoint;
    public BreakingPlatform platform;
    public GameObject gameOverScreen;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // SceneManager.LoadScene("GameOver");
            gameOverScreen.SetActive(true);
        }
    }

    private void MoveToSpawn()
    {
        player.transform.position = respawnPoint.position;
    }

    public void ResetScene()
    {
        MoveToSpawn();
        platform.ResetPlatform();
        gameOverScreen.SetActive(false);
    }
}
