using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImmunityButton : MonoBehaviour
{
    public Button Disable;
    public PlayerImmunity playerImmunity;
    public Image cooldownOverlay;
    public float cooldownDuration = 5f;

    private bool _isOnCooldown = false;

    void Start()
    {
       Debug.Log($"Button active: {gameObject.activeSelf}, pos: {transform.position}");

 
        if (Disable == null)
        {
            Disable = GetComponent<Button>();
            Disable.onClick.AddListener(ActivateImmunity);
        }

        if (cooldownOverlay != null)
        {
            cooldownOverlay.type = Image.Type.Filled;
            cooldownOverlay.fillAmount = 0;
            cooldownOverlay.raycastTarget = false;
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
        Disable.interactable = false;
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

        Disable.interactable = true;
        _isOnCooldown = false;
    }
}