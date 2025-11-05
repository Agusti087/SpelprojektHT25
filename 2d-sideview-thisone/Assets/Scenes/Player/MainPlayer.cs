using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{
    public float Cold, MaxCold, ColdIncrease, Logs;
    [SerializeField] private BarBehaviour ColdBar;

    void Start()
    {
        ColdBar.SetMaxCold(MaxCold);
    }

    void Update()
    {
        Cold += ColdIncrease * Time.deltaTime;
        Cold = Mathf.Clamp(Cold, 0, MaxCold);
        ColdBar.SetCold(Cold);
        if (Cold >= MaxCold)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
