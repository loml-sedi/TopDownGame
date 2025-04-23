using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public SpriteRenderer playerSprite;
    public bool isImmune = false;

    void Update()
    {
        Vector3 moveDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        ).normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void ActivateImmunity(float duration)
    {
        if (!isImmune)
            StartCoroutine(ImmunityRoutine(duration));
    }

    private IEnumerator ImmunityRoutine(float duration)
    {
        isImmune = true;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            playerSprite.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(0.1f);
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.2f;
        }

        isImmune = false;
    }
}