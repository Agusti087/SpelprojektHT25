using UnityEngine;

public class Campfireplacement : MonoBehaviour
{

    public bool DoWeHaveTheWood;
    public bool Placeable;
    MainPlayer WoodAmount;
    public GameObject CampfireObj1;
    public GameObject CampfireObj2;
    public GameObject CampfireObj3;
    public GameObject CampfireObj4;
    public GameObject PlacePoint;
    [SerializeField] int WoodCost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WoodAmount = FindAnyObjectByType<MainPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && Placeable == true && DoWeHaveTheWood == true)
        {
           GameObject PlacePoint =  Instantiate(CampfireObj1,WoodAmount.transform);
            PlacePoint.transform.position = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.C) && Placeable == true && DoWeHaveTheWood == false)
        {
           GameObject PlacePoint = Instantiate(CampfireObj2, WoodAmount.transform);
            PlacePoint.transform.position = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.C) && Placeable == false && DoWeHaveTheWood == true)
        {
            GameObject PlacePoint = Instantiate(CampfireObj3, WoodAmount.transform);
            PlacePoint.transform.position = Vector3.zero;
        }
        if (Input.GetKeyDown(KeyCode.C) && Placeable == false && DoWeHaveTheWood == false)
        {
            GameObject PlacePoint = Instantiate(CampfireObj4, WoodAmount.transform);
            PlacePoint.transform.position = Vector3.zero;
        }
        if (WoodAmount.Logs >= WoodCost)
        {
            DoWeHaveTheWood = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
