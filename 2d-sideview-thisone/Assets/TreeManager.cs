using UnityEngine;

public class TreeManager : MonoBehaviour
{
    [Header("Tree Spawn Settings")]
    [SerializeField] private GameObject treePrefab; // Assign your tree prefab
    [SerializeField] private int treeCount = 10;    // How many trees to spawn
    [SerializeField] private float minX = -3.75f;
    [SerializeField] private float maxX = 9.5f;
    [SerializeField] private float yLevel = 4f;

    // How far left/right trees can spawn outside the blocked area
    [SerializeField] private float outerSpawnRange = 20f;

    void Start()
    {
        SpawnTrees();
    }

    private void SpawnTrees()
    {
        if (treePrefab == null)
        {
            Debug.LogError("Tree prefab not assigned in TreeManager!");
            return;
        }

        for (int i = 0; i < treeCount; i++)
        {
            float randomX = GetRandomXOutsideRange();
            Vector2 spawnPos = new Vector2(randomX, yLevel);
            Instantiate(treePrefab, spawnPos, Quaternion.identity);
        }

        Debug.Log($"{treeCount} trees spawned outside X range ({minX}, {maxX}) at Y = {yLevel}");
    }

    private float GetRandomXOutsideRange()
    {
        // 50/50 chance to spawn left or right side
        bool spawnLeft = Random.value < 0.5f;
        if (spawnLeft)
        {
            // Spawn somewhere LEFT of minX
            return Random.Range(minX - outerSpawnRange, minX);
        }
        else
        {
            // Spawn somewhere RIGHT of maxX
            return Random.Range(maxX, maxX + outerSpawnRange);
        }
    }
}
