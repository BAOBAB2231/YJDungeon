using System.Collections;
using UnityEngine;

public class ItemRespawner : MonoBehaviour
{
    public string prefabName;
    public float respawnTime = 10f;

    public void Respawn(Vector3 position)
    {
        StartCoroutine(RespawnRoutine(position));
    }

    private IEnumerator RespawnRoutine(Vector3 position)
    {
        yield return new WaitForSeconds(respawnTime);

        GameObject prefab = Resources.Load<GameObject>($"RespawnPrefabs/{prefabName}");

        Instantiate(prefab, position, Quaternion.identity);
        Destroy(gameObject);
    }
}
