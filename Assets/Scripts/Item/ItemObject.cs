using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    public string respawnerPrefabName;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.itemData = data;
            player.useItem?.Invoke();

            GameObject go = new GameObject("Respawner");
            ItemRespawner respawner = go.AddComponent<ItemRespawner>();
            respawner.prefabName = respawnerPrefabName;
            respawner.Respawn(transform.position);

            Destroy(gameObject);
        }
    }

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        // E키를 쓸 때 구현.
    }
}
