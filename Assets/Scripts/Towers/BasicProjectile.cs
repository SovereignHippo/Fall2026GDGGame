using UnityEngine;

public class BasicProjectile : MonoBehaviour
{

    private Transform targetTransform;

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
        if(targetTransform != null)
        {
            //move towards enemy

            transform.position += new Vector3(1, 0, 0); //TEST CODE
        }


        //On hit delete itself

        // delete itself if goes out of range
        if(range != 0)
        {
            if ((transform.position - startingPosition).magnitude > range)
            {
                Destroy(gameObject);
            }
        }
        


    }

    public void SetTarget(Transform targetLocation)
    {
        targetTransform = targetLocation;
    }

    public void SetRange(float newRange)
    {
        range = newRange;
    }
}
