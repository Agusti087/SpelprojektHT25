using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private MainPlayer player;
    [SerializeField] private float warmRange = 5f;
    [SerializeField] private float warmMultiplier = -1f;
    [SerializeField] private int requiredLogs = 3;
    [SerializeField] private float burnTime = 30f;
    [SerializeField] private FireBarBehaviour fireBar; // Dra in baren från scenen här
    [SerializeField] private Vector3 barOffset = new Vector3(0, 2f, 0);

    private float originalColdIncrease;
    private bool isLit = false;
    private float burnTimer = 0f;
    private Camera mainCam;

    void Start()
    {
        originalColdIncrease = player.ColdIncrease;
        mainCam = Camera.main;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (!isLit && Input.GetKeyDown(KeyCode.Q))
        {
            if (distance <= warmRange && player.Logs >= requiredLogs)
            {
                player.Logs -= requiredLogs;
                isLit = true;
                burnTimer = burnTime;
                fireBar.SetMaxBurnTime(burnTime);
            }
        }

        if (isLit)
        {
            burnTimer -= Time.deltaTime;
            if (burnTimer <= 0f)
            {
                isLit = false;
                player.ColdIncrease = originalColdIncrease;
                burnTimer = 0f;
            }
        }

        if (isLit && distance <= warmRange)
        {
            // Elden är tänd och spelaren är nära
            player.ColdIncrease = -Mathf.Abs(originalColdIncrease) * 0.5f; // halverad kyla
        }
        else
        {
            player.ColdIncrease = originalColdIncrease;
        }

        if (fireBar != null)
        {
            fireBar.SetBurnTime(burnTimer);
        }
    }
}
