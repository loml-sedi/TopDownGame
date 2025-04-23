using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImmunityButton : MonoBehaviour
{
    [Header("References")]
    public Button button;
    public PlayerImmunity playerImmunity;
    public Image cooldownOverlay;

    [Header("Settings")]
    public float cooldownDuration = 5f;

    private bool _isOnCooldown = false;

    void Start()
    {
        if (button == null) button = GetComponent<Button>();
        button.onClick.AddListener(ActivateImmunity);

        if (cooldownOverlay != null)
        {
            cooldownOverlay.type = Image.Type.Filled;
            cooldownOverlay.fillAmount = 0;
            cooldownOverlay.raycastTarget = false; // Important: prevents overlay from blocking clicks
        }
    }

    public void ActivateImmunity()
    {
        if (!_isOnCooldown && playerImmunity != null && !playerImmunity.IsImmune())
        {
            playerImmunity.ActivateImmunity();
            StartCoroutine(CooldownRoutine());
        }
    }

    private IEnumerator CooldownRoutine()
    {
        _isOnCooldown = true;
        button.interactable = false;
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

        button.interactable = true;
        _isOnCooldown = false;
    }
}