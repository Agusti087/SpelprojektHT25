using UnityEngine;

public class DaysManager : MonoBehaviour
{
    public int Days;
    private float timer = 0f;
    private float interval = 300f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            Days++;
            timer = 0f;
            Debug.Log("Days: " + Days);
        }
    }
}
