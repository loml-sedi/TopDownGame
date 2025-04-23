using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
 *Monkey, C. (2020). Unity Button Interaction Fix. . Retrieved from YouTube: https://www.youtube.com/watch?v=vmKxLibGrMo 
 *Brackeys. (2016). Unity Buttons Complete Guide. Retrieved from YouTube: https://www.youtube.com/watch?v=zc8ac_qUXQY
 *Monkey, C. (2021). UI Cooldown Effects in Unity. Retrieved from YouTube: https://www.youtube.com/watch?v=1qbjmb_1hV4 
 *Monkey, C. (2023). Canvas, Buttons, Text. [YouTube video. Retrieved from YouTube: https://www.youtube.com/watch?v=zc8ac_qUXQY 
 *Monkey, C. (2023). Unity UI Tutorial. Retrieved from YouTube: https://www.youtube.com/watch?v=3I5d2rUJ0pE
 */

public class ImmunityButton : MonoBehaviour
{
    public PlayerImmunity playerImmunity;
    public Image cooldownOverlay;
    public float cooldownDuration = 5f;
    public Vector2 screenPosition = new Vector2(0, -200); 

    private Button _button;
    private RectTransform _rectTransform;
    private bool _isCooldownActive;

    void Awake()
    {
        _button = GetComponent<Button>();
        _rectTransform = GetComponent<RectTransform>();
        _rectTransform.anchoredPosition = screenPosition;
        _rectTransform.sizeDelta = new Vector2(200, 80);

        if (cooldownOverlay != null)
        {
            cooldownOverlay.type = Image.Type.Filled;
            cooldownOverlay.fillMethod = Image.FillMethod.Radial360;
            cooldownOverlay.fillAmount = 0;
            cooldownOverlay.raycastTarget = false;
        }
        else
        {
            Debug.LogWarning("Cooldown overlay not assigned!", this);
        }
    }

    [System.Obsolete]
    void Start()
    {
        if (playerImmunity == null)
        {
            playerImmunity = FindObjectOfType<PlayerImmunity>();
            if (playerImmunity == null)
                Debug.LogError("No PlayerImmunity found in scene!", this);
        }

        _button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        if (!_isCooldownActive && playerImmunity != null && !playerImmunity.IsImmune())
        {
            playerImmunity.ActivateImmunity();
            StartCoroutine(CooldownRoutine());
        }
    }

    IEnumerator CooldownRoutine()
    {
        _isCooldownActive = true;
        _button.interactable = false;
        float timer = cooldownDuration;

        while (timer > 0)
        {
            if (cooldownOverlay != null)
                cooldownOverlay.fillAmount = timer / cooldownDuration;

            timer -= Time.deltaTime;
            yield return null;
        }

        if (cooldownOverlay != null)
            cooldownOverlay.fillAmount = 0;

        _button.interactable = true;
        _isCooldownActive = false;
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        if (_rectTransform == null)
            _rectTransform = GetComponent<RectTransform>();

        _rectTransform.anchoredPosition = screenPosition;
    }
#endif
}
