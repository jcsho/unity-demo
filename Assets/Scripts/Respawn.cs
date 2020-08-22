using UnityEngine;

public class Respawn : MonoBehaviour
{

    public PlayerController player;
    public Transform respawnPoint;
    public BreakingPlatform platform;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveToSpawn();
            platform.ResetPlatform();
        }
    }

    private void MoveToSpawn()
    {
        player.transform.position = respawnPoint.position;
    }
}
