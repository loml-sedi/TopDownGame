using UnityEngine;
using System.Collections;

public class endGame : MonoBehaviour
{
    [SerializeField] private GameObject blackScreenPanel;
    [SerializeField] private PuppetMove puppetScript;
    private bool _hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_hasTriggered && puppetScript.IsFollowing)
        {
            _hasTriggered = true;
            StartCoroutine(ShowBlackScreen());
        }
    }

    private IEnumerator ShowBlackScreen()
    {
        blackScreenPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
    }
}