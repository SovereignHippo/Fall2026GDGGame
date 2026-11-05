using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField] private int enemyLayer;
    [SerializeField] private float speed;
    
    private int collisionsLeft = 1;

    private Vector3 targetDirection;

    private Vector3 startingPosition;

    private float range;

    private List<GameObject> hits = new List<GameObject>();


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
        

        
        for (int i = 0; i < hits.Count; i++)
        {
            if (collisionsLeft <= 0)
            {
                Destroy(gameObject);
                break;
            }

            GameObject hitGameObject = hits[0];
            collisionsLeft--;
            hitGameObject.GetComponent<EnemyScript>().EnemyHit();
        }

        if (collisionsLeft <= 0)
        {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer != enemyLayer)
        {
            return;
        }

        hits.Add(collision.gameObject);
    }

    public void SetTarget(Vector3 targetLocation, Transform towerLocation)
    {
        targetDirection = targetLocation - towerLocation.position;
        
    }

    public void SetRange(float newRange)
    {
        range = newRange;
    }

    public void SetCollisionAmount(int collisions)
    {
        collisionsLeft = collisions;
    }
    
}
