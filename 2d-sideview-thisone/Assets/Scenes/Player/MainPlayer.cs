using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    [Header("Cold Settings")]
    public float Cold;
    public float MaxCold = 100f;
    public float ColdIncrease = 1f;
    public float Logs = 0;
    [SerializeField] private BarBehaviour ColdBar;

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

    void Update()
    {
        HandleCold();
        //HandleCampfireBuild();
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
