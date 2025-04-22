using UnityEngine;



public class collectabel : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private collectableManager collectableManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        collectableManager = collectableManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)

            hasTriggered = true;
        //for score.
        collectableManager.Changecollectable(value);
        Destroy(gameObject);
    }
}

