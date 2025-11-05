using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private MainPlayer player;
    [SerializeField] private float warmRange = 5f;
    [SerializeField] private float maxWarmMultiplier = -4f; // konstant värmeeffekt
    [SerializeField] private int requiredLogs = 3;
    [SerializeField] private float burnTime = 30f;
    [SerializeField] private FireBarBehaviour fireBar;

    private bool isLit = false;
    private float burnTimer = 0f;
    private float baselineColdIncrease; // konstant referensvärde

    void Start()
    {
        baselineColdIncrease = player.ColdIncrease; // spara spelarens baseline
        fireBar?.SetMaxBurnTime(burnTime);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        // Tänd eller lägg på ved
        if (Input.GetKeyDown(KeyCode.Q) && distance <= warmRange)
        {
            if (!isLit)
                TryLightFire();
            else
                TryAddLogs();
        }

        // Nedbränning
        if (isLit)
        {
            burnTimer -= Time.deltaTime;
            if (burnTimer <= 0f)
            {
                isLit = false;
                burnTimer = 0f;
            }
        }

        // Värmeeffekt – konstant när elden är tänd
        if (isLit && distance <= warmRange)
        {
            player.ColdIncrease = maxWarmMultiplier;
        }
        else
        {
            player.ColdIncrease = baselineColdIncrease;
        }

        fireBar?.SetBurnTime(burnTimer);
    }

    private void TryLightFire()
    {
        if (player.Logs >= requiredLogs)
        {
            player.Logs -= requiredLogs;
            isLit = true;
            burnTimer = burnTime;
            fireBar?.SetMaxBurnTime(burnTime);
        }
    }

    private void TryAddLogs()
    {
        if (player.Logs <= 0 && requiredLogs > 0)
            return;

        if (player.Logs > 0)
            player.Logs--;

        // Lägg på en fast mängd burnTime per ved istället för multipel baserat på FireStrength
        float addedBurnTime = burnTime / Mathf.Max(1, requiredLogs);
        burnTimer += addedBurnTime;
        burnTimer = Mathf.Min(burnTimer, burnTime);

        if (!isLit && burnTimer > 0f)
            isLit = true;

        fireBar?.SetBurnTime(burnTimer);
    }
}
