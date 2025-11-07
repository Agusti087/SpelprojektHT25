using UnityEngine;

public class CampFire : MonoBehaviour
{
    [Header("Campfire Settings")]
    [SerializeField] private float warmRange = 5f;
    [SerializeField] private float maxWarmMultiplier = -4f;
    [SerializeField] private int requiredLogs = 3;
    [SerializeField] private float burnTime = 30f;
    [SerializeField] private int maxRefills = 3;

    private int refillCount = 0;
    private bool isLit = false;
    private float burnTimer = 0f;
    private float baselineColdIncrease;

    private MainPlayer player;
    private FireBarBehaviour fireBar;

    void Awake()
    {
        // Find the player automatically
        if (player == null)
            player = FindObjectOfType<MainPlayer>();

        if (player != null)
            baselineColdIncrease = player.ColdIncrease;

        // Find FireBar in scene
        fireBar = FindObjectOfType<FireBarBehaviour>();
        if (fireBar != null)
            fireBar.SetMaxBurnTime(burnTime);
        else
            Debug.LogError("FireBarBehaviour not found in the scene!");
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Interact with campfire
        if (Input.GetKeyDown(KeyCode.Q) && distance <= warmRange)
        {
            if (!isLit)
                TryLightFire();
            else
                TryAddLogs();
        }

        // Burn timer
        if (isLit)
        {
            burnTimer -= Time.deltaTime;
            if (burnTimer <= 0f)
            {
                isLit = false;
                burnTimer = 0f;
            }
        }

        // Apply warm effect
        if (isLit && distance <= warmRange)
            player.ColdIncrease = maxWarmMultiplier;
        else
            player.ColdIncrease = baselineColdIncrease;

        // Update the bar
        if (fireBar != null)
            fireBar.SetBurnTime(burnTimer);
    }

    private void TryLightFire()
    {
        if (player.Logs >= requiredLogs)
        {
            player.Logs -= requiredLogs;
            isLit = true;
            burnTimer = burnTime;
            refillCount = 0;

            if (fireBar != null)
                fireBar.SetMaxBurnTime(burnTime);
        }
    }

    private void TryAddLogs()
    {
        if (refillCount >= maxRefills)
        {
            Destroy(gameObject);
            return;
        }

        if (player.Logs <= 0)
            return;

        player.Logs--;

        float addedBurnTime = burnTime / Mathf.Max(1, requiredLogs);
        burnTimer += addedBurnTime;
        burnTimer = Mathf.Min(burnTimer, burnTime);

        if (!isLit && burnTimer > 0f)
            isLit = true;

        if (fireBar != null)
            fireBar.SetBurnTime(burnTimer);

        refillCount++;
    }
}
