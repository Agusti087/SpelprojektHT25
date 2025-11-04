using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private MainPlayer player;
    [SerializeField] private float warmRange = 5f;
    [SerializeField] private float warmMultiplier = -1f;
    [SerializeField] private int requiredLogs = 3;
    [SerializeField] private float burnTime = 30f;

    private float originalColdIncrease;
    private bool isLit = false;
    private float burnTimer = 0f;

    void Start()
    {
        originalColdIncrease = player.ColdIncrease;
    }

    void Update()
    {
        if (!isLit && Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= warmRange && player.Logs >= requiredLogs)
            {
                player.Logs -= requiredLogs;
                isLit = true;
                burnTimer = burnTime;
            }
        }

        if (isLit)
        {
            burnTimer -= Time.deltaTime;
            if (burnTimer <= 0f)
            {
                isLit = false;
                player.ColdIncrease = originalColdIncrease;
            }
        }

        float currentDistance = Vector3.Distance(transform.position, player.transform.position);
        if (isLit && currentDistance <= warmRange)
        {
            player.ColdIncrease = Mathf.Abs(originalColdIncrease) * warmMultiplier;
        }
        else if (!isLit || currentDistance > warmRange)
        {
            player.ColdIncrease = originalColdIncrease;
        }
    }
}
