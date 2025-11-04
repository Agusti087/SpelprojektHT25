using UnityEngine;

public class treehealth : MonoBehaviour
{
    public int health = 10;
    public bool Collided;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (Collided = true && Input.GetKeyDown(KeyCode.F))
        {
            health -= 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("axe"))
        {
            Collided = true;
        }

    }
}

