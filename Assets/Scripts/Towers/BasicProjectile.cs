using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField] private int enemyLayer;
    [SerializeField] private float speed;

    private Vector3 targetDirection;

    private Vector3 startingPosition;

    private float range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(targetDirection != null)
        {
            
            //move towards enemy
            transform.position += Vector3.Normalize(targetDirection) * speed * Time.deltaTime;
        }


        

        // delete itself if goes out of range
        if(range != 0)
        {
            if ((transform.position - startingPosition).magnitude > range)
            {
                Destroy(gameObject);
            }
        }
        


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //On hit delete itself
        if (collision.gameObject.layer == enemyLayer)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform targetLocation, Transform towerLocation)
    {
        targetDirection = targetLocation.position - towerLocation.position;
        
    }

    public void SetRange(float newRange)
    {
        range = newRange;
    }
}
