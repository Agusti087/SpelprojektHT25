using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainPlayer : MonoBehaviour
{
    public float Cold, MaxCold, ColdIncrease;
    public int Logs;
    [SerializeField] private BarBehaviour ColdBar;
    [SerializeField] TMP_Text LogText;
    [SerializeField] public int AxeDamage;
    [SerializeField] public int CampfireCost;

    

    void Start()
    {
        ColdBar.SetMaxCold(MaxCold);
    }

    public void Update()
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

