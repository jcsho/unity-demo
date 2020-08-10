using TMPro;
using UnityEngine;

public class FlashingColor : MonoBehaviour
{

    public BreakingPlatform platform;

    public Color flashingColor;

    private float _timer;
    private float _maxTimerValue;

    private MeshRenderer _renderer;
    private Color _originalColor;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _maxTimerValue = platform.GetTimer();
        _originalColor = _renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        _timer = Mathf.Clamp(platform.GetTimer(), 0.01f, 1f);

        float lerp = Mathf.PingPong(Time.time, _timer) / _timer;
        _renderer.material.color = Color.Lerp(_originalColor, flashingColor, lerp);
    }
}
