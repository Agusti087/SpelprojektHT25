using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{
    public float Cold, MaxCold, Width, Height;

    [SerializeField]
    private RectTransform ColdBar;

    public void SetMaxCold(float maxCold)
    {
        MaxCold = maxCold;
    }

    public void SetCold(float cold)
    {
        Cold = cold;
        float newWidth = (Cold/ MaxCold) * Width;

        ColdBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
