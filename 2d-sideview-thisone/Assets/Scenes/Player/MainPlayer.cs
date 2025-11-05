using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{
    public float Cold, MaxCold, ColdIncrease = 1f, Logs;
    [SerializeField] private BarBehaviour ColdBar;

    public float ColdChangeInterval = 2f;
    private float coldChangeTimer = 0f;

    void Start()
    {
        ColdBar.SetMaxCold(MaxCold);
    }

    void Update()
    {
        coldChangeTimer += Time.deltaTime;
        if (coldChangeTimer >= ColdChangeInterval)
        {
            RandomizeColdIncrease();
            coldChangeTimer = 0f;
        }

        Cold += ColdIncrease * Time.deltaTime;
        Cold = Mathf.Clamp(Cold, 0, MaxCold);
        ColdBar.SetCold(Cold);

        if (Cold >= MaxCold)
        {
            Die();
        }
    }

    void RandomizeColdIncrease()
    {
        ColdIncrease = Random.Range(1f, 3f);
        Debug.Log("New ColdIncrease: " + ColdIncrease);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
