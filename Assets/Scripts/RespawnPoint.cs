using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 1, 0), new Vector3(1, 2, 1));
    }
}
