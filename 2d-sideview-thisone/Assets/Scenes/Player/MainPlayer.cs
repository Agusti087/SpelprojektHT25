using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{
    public float Cold, MaxCold, ColdIncrease, Logs;

    [SerializeField]
    private BarBehaviour ColdBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ColdBar.SetMaxCold(MaxCold);
    }

    // Update is called once per frame
    void Update()
    {
        Cold += ColdIncrease * Time.deltaTime;
        Cold = Mathf.Clamp(Cold, 0, MaxCold);

        ColdBar.SetCold(Cold);
    }
}
