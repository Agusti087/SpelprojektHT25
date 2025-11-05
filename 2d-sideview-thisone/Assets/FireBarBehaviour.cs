using UnityEngine;

public class FireBarBehaviour : MonoBehaviour
{
    public float BurnTime, MaxBurnTime;
    private float Width, Height;
    [SerializeField] private RectTransform FillBar;

    void Start()
    {
        if (FillBar == null)
        {
            Debug.LogError("FillBar saknas i FireBarBehaviour!");
            return;
        }

        // Hämta den aktuella bredden/höjden på baren
        Width = FillBar.sizeDelta.x;
        Height = FillBar.sizeDelta.y;
    }

    public void SetMaxBurnTime(float maxTime)
    {
        MaxBurnTime = maxTime;
        BurnTime = maxTime;
        FillBar.sizeDelta = new Vector2(Width, Height); // starta full
    }

    public void SetBurnTime(float time)
    {
        BurnTime = Mathf.Clamp(time, 0, MaxBurnTime);
        float ratio = MaxBurnTime > 0 ? (BurnTime / MaxBurnTime) : 0f;
        FillBar.sizeDelta = new Vector2(Width * ratio, Height);
    }
}
