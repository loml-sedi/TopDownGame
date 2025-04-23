using UnityEngine;

public class MagicBox : MonoBehaviour
{
    [Header("Settings")]
    public int requiredObjects = 5;
    public GameObject puppetPrefab;
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DepositObjects();
        }
    }

    void DepositObjects()
    {
        collectableManager manager = collectableManager.instance;

        Debug.Log($"Current objects: {manager.GetCurrentCollectable()}, Required: {requiredObjects}");

        if (manager.GetCurrentCollectable() >= requiredObjects)
        {
            Debug.Log("Attempting to spawn puppet...");
            if (puppetPrefab == null) Debug.LogError("Missing puppetPrefab!");
            if (spawnPoint == null) Debug.LogError("Missing spawnPoint!");

            Instantiate(puppetPrefab, spawnPoint.position, Quaternion.identity);
            manager.Changecollectable(-requiredObjects);
            Debug.Log("Puppet spawned successfully!");
        }

        if (manager.GetCurrentCollectable() >= requiredObjects)
        {
            Instantiate(puppetPrefab, spawnPoint.position, Quaternion.identity);

            manager.Changecollectable(-requiredObjects);
        }
    }
}