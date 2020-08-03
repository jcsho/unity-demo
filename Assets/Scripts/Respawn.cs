using UnityEngine;

public class Respawn : MonoBehaviour
{

    public PlayerController player;
    public Transform respawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveToSpawn();
        }
    }

    private void MoveToSpawn()
    {
        player.transform.position = respawnPoint.position;
    }
}
