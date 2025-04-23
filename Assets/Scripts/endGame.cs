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
            Ending(); // Ending the Scene.
            
        }
    }
    
    private IEnumerator ShowBlackScreen()
    {
        blackScreenPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
    }
    void Ending()
    {
        if (QUIT.instance != null)
        {
            QUIT.instance.Quitgame();
            print("End of Scene");
           
        }
       
    }
}