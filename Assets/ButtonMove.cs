using UnityEngine;
using UnityEngine.UI;

public class ButtonMove : MonoBehaviour
{
    [Header("Settings")]
    public Transform player;          
    public Vector2 screenOffset = new Vector2(100, -100);
    public float smoothSpeed = 5f;  

    private RectTransform _rectTransform;
    private Camera _mainCam;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCam = Camera.main;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 screenPos = _mainCam.WorldToScreenPoint(player.position);

        _rectTransform.position = Vector2.Lerp(
            _rectTransform.position,
            screenPos + screenOffset,
            smoothSpeed * Time.deltaTime
        );
    }
}
