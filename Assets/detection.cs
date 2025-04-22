using UnityEngine;

public class detection : MonoBehaviour
{
    public float rotateSpeed;
    public float distance;
    public LineRenderer lineOfContact;
    public Gradient redColour;
    public Gradient greenColour;
      

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

            lineOfContact.SetPosition(1, hitInfo.point);
            lineOfContact.colorGradient = redColour;

            if (hitInfo.collider.CompareTag("Player"))
            {



                //Destroy(hitInfo.collider.gameObject);
                DHealth();


            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfContact.SetPosition(1, transform.position + transform.right * distance);
            lineOfContact.colorGradient = greenColour;
        }

        lineOfContact.SetPosition(0, transform.position);
    }

    public void DHealth()
    {
        HeartSystem.instance.TakeDamage(1);
        HeartSystem.instance.restartGame();
    }
        
}
