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

    

    [Header("Cold Timing")]
    public float ColdChangeInterval = 2f;
    private float coldChangeTimer = 0f;

    [Header("Day/Night Settings")]
    public bool isDay = true;
    public float nightMultiplier = 2f;

    [Header("Campfire Settings")]
    [SerializeField] private GameObject campfirePrefab;
    [SerializeField] private float campfireDistance = 2f;

    void Start()
    {
        if (ColdBar != null)
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

        ColdBar?.SetCold(Cold);

        if (Cold >= MaxCold)
            Die();
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

   // private void HandleCampfireBuild()
    //{
        //if (Input.GetKeyDown(KeyCode.C))
        //{
          //  if (Logs >= 15 && campfirePrefab != null)
            //{
              //  Vector3 spawnPos = transform.position + transform.forward * campfireDistance;
                //GameObject newCampfire = Instantiate(campfirePrefab, spawnPos, Quaternion.identity);

                //CampFire campfireScript = newCampfire.GetComponent<CampFire>();
                //if (campfireScript != null)
                  //  campfireScript.Initialize(this);

//                Logs -= 15;
  //          }
    //        else
      //      {
        //    }
        //}
    //}
}

