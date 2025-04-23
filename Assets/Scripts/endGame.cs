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
/*
 * Brackeys. (2017). How to Make a Fade to Black Screen in Unity. Retrieved from YouTube: https://www.youtube.com/watch?v=0HwZQt94uHQ 
 */