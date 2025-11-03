using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private MainPlayer player;
    [SerializeField] private float warmRange = 5f; // hur nära man måste vara
    [SerializeField] private float warmMultiplier = -1f; // multipliceras med spelarens ColdIncrease när spelaren är nära

    private float originalColdIncrease; // lagra spelarens normala värde

    void Start()
    {
        // Spara spelarens ursprungliga ColdIncrease
        originalColdIncrease = player.ColdIncrease;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= warmRange)
        {
            // Spelaren är nära elden → använd negativ version
            player.ColdIncrease = Mathf.Abs(originalColdIncrease) * warmMultiplier;
        }
        else
        {
            // För långt bort → återställ till normalt värde
            player.ColdIncrease = originalColdIncrease;
        }
    }
}
