using UnityEngine;
using UnityEngine.UI;

public class FireBarBehaviour : MonoBehaviour
{
    public float BurnTime, MaxBurnTime, Width, Height;
    [SerializeField] private RectTransform FillBar;

    public void SetMaxBurnTime(float maxTime)
    {
        MaxBurnTime = maxTime;
    }

    public void SetBurnTime(float time)
    {
        BurnTime = time;
        float newWidth = (BurnTime / MaxBurnTime) * Width;
        FillBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
