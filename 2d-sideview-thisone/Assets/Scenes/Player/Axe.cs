using UnityEngine;

public class Axe : MonoBehaviour
{
    public float Axe_Damage = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //aktiveras varje gång något kolliderar med objektet
    {
        if (collision.CompareTag("trees"))
        {
            chop();
            print("gröna beanaise");
        }
    }


    private void chop()
    {
        if (Input.GetKey(KeyCode.F))
        {
            print("lingonsylt");

        }
    }
}
