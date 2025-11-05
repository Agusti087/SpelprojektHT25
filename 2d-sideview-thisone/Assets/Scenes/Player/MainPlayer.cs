using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPlayer : MonoBehaviour
{
    public float Cold, MaxCold, ColdIncrease, Logs;
    [SerializeField] private BarBehaviour ColdBar;
    [SerializeField] TMP_Text LogText;

    

    void Start()
    {
        ColdBar.SetMaxCold(MaxCold);
    }

    public void Update()
    {
        Cold += ColdIncrease * Time.deltaTime;
        Cold = Mathf.Clamp(Cold, 0, MaxCold);
        ColdBar.SetCold(Cold);
        LogText.text = $"{Logs}";
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

