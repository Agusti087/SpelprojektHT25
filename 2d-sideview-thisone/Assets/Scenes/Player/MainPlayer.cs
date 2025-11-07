using UnityEngine;
using TMPro;

public class MainPlayer : MonoBehaviour
{
    [Header("Player Stats")]
    public float Cold, MaxCold, ColdIncrease;
    public int Logs;
    [SerializeField] private BarBehaviour ColdBar;
    [SerializeField] private TMP_Text LogText;
    [SerializeField] public int AxeDamage = 5;

    [Header("Cold Timing")]
    public float ColdChangeInterval = 2f;
    private float coldChangeTimer = 0f;

    [Header("Day/Night Settings")]
    public bool isDay = true;
    public float nightMultiplier = 2f;

    void Start()
    {
        if (ColdBar != null)
            ColdBar.SetMaxCold(MaxCold);
    }

    void Update()
    {
        HandleCold();

        // Update UI
        ColdBar?.SetCold(Cold);
        LogText.text = $"{Logs}";

        if (Cold >= MaxCold)
            Die();
    }

    private void HandleCold()
    {
        coldChangeTimer += Time.deltaTime;
        if (coldChangeTimer >= ColdChangeInterval)
        {
            RandomizeColdIncrease();
            coldChangeTimer = 0f;
        }

        float currentColdIncrease = ColdIncrease * Time.deltaTime;
        if (!isDay)
            currentColdIncrease *= nightMultiplier;

        Cold += currentColdIncrease;
        Cold = Mathf.Clamp(Cold, 0, MaxCold);
    }

    private void RandomizeColdIncrease()
    {
        ColdIncrease = Random.Range(1f, 3f);
    }

    private void Die()
    {
        Debug.Log("Player froze to death!");
        Destroy(gameObject);
    }
}
