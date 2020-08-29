using UnityEngine;

public class FlashingColor : MonoBehaviour
{

    public BreakingPlatform platform;

    public Color flashingColor;

    private float _timer;
    private float _maxTimerValue;

    private MeshRenderer[] _renderer;
    private Color _originalColor;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = platform.GetPlatformMeshes();
        _maxTimerValue = platform.GetTimer();
        _originalColor = _renderer[0].material.color;
    }

    // Update is called once per frame
    void Update()
    {
        _timer = Mathf.Clamp(platform.GetTimer(), 0.01f, 1f);

        ChangeMaterialColor();
    }

    private void ChangeMaterialColor()
    {
        for (int i = 0; i < _renderer.Length; i++)
        {
            if (platform.GetTimer() < _maxTimerValue && platform.GetTimer() > 0.01f)
            {
                float lerp = Mathf.PingPong(Time.time, _timer) / _timer;
                _renderer[i].material.color = Color.Lerp(_originalColor, flashingColor, lerp);
            }
            else
            {
                _renderer[i].material.color = _originalColor;
            }
        }
    }
}
