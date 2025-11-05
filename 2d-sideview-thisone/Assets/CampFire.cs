using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private MainPlayer player;
    [SerializeField] private float warmRange = 5f;
    [SerializeField] private float maxWarmMultiplier = -1f;
    [SerializeField] private int requiredLogs = 3;
    [SerializeField] private float burnTime = 30f;
    [SerializeField] private FireBarBehaviour fireBar;
    [SerializeField] private Vector3 barOffset = new Vector3(0, 2f, 0);

    private float originalColdIncrease;
    private bool isLit = false;
    private float burnTimer = 0f;
    private float maxBurnTime;
    private Camera mainCam;

    private float FireStrength => Mathf.Clamp01(burnTimer / maxBurnTime);

    void Start()
    {
        originalColdIncrease = player.ColdIncrease;
        mainCam = Camera.main;
        maxBurnTime = burnTime;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (Input.GetKeyDown(KeyCode.Q) && distance <= warmRange)
        {
            if (!isLit)
                TryLightFire();
            else
                TryAddLogs();
        }

        if (isLit)
        {
            burnTimer -= Time.deltaTime;
            if (burnTimer <= 0f)
            {
                isLit = false;
                burnTimer = 0f;
                player.ColdIncrease = originalColdIncrease;
            }
        }

        if (isLit && distance <= warmRange)
        {
           
            float warmth = Mathf.Lerp(originalColdIncrease, maxWarmMultiplier, FireStrength);
            player.ColdIncrease = warmth;
        }
        else
        {
            
            player.ColdIncrease = originalColdIncrease;
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
            maxBurnTime = burnTime;
            fireBar?.SetMaxBurnTime(burnTime);
        }
    }

    private void TryAddLogs()
    {
        if (player.Logs <= 0 && requiredLogs > 0)
            return;

        if (player.Logs > 0)
            player.Logs--;

        float addMultiplier = Mathf.Lerp(1.2f, 0.5f, FireStrength);
        float addedBurnTime = (burnTime / Mathf.Max(1, requiredLogs)) * addMultiplier;

        burnTimer += addedBurnTime;
        burnTimer = Mathf.Min(burnTimer, maxBurnTime);

        if (!isLit && burnTimer > 0f)
            isLit = true;

        fireBar?.SetBurnTime(burnTimer);
    }
}
