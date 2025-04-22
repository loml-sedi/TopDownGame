using UnityEngine;
using TMPro;

public class collectableManager : MonoBehaviour
{
    public static collectableManager instance;

    private int collectable;
    [SerializeField] private TMP_Text collectableDisplay;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    // Public method to GET the current value
    public int GetCurrentCollectable()
    {
        return collectable;
    }

    // Public method to MODIFY the value
    public void Changecollectable(int amount)
    {
        collectable += amount;
        collectableDisplay.text = collectable.ToString();
    }
}