using UnityEngine;

public class DaysManager : MonoBehaviour
{
    public int Days = 0;
    public bool isDay = true;
    private float timer = 0f;
    private float cycleDuration = 300f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cycleDuration)
        {
            isDay = !isDay;
            timer = 0f;

            if (isDay)
            {
                Days++;
            }
            else
            {

            }
        }
    }
}
