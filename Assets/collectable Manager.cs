using UnityEngine;
using TMPro;
public class collectableManager : MonoBehaviour
{
    public static collectableManager instance;

    private int collectable;
    [SerializeField] private TMP_Text collectableDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        collectableDisplay.text = collectable.ToString();
    }
    public void Changecollectable(int amount)
    {
        collectable += amount;
    }
}

