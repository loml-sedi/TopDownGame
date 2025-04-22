using UnityEngine;

public class PuppetFollow : MonoBehaviour
{
    [Header("Follow Settings")]
    public float followSpeed = 3f;
    public float followDistance = 1f;

    private Transform player;

    void Start()
    {
        // Automatically find player by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
            Debug.LogError("No GameObject with tag 'Player' found!");
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            if (direction.magnitude > followDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    player.position,
                    followSpeed * Time.deltaTime
                );
            }
        }
    }
}