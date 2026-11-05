using System;
using System.Net.Http.Headers;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private int target = 1;
    private GameObject TargetParentObject;
    private int health;
    private float speed = 1.0f;


    void Start()
    {
        TargetParentObject = GameObject.Find("PathfindingObjects");
    }

    public int GetTargetInt()
    {
        return target;
    }


    public void Setup(int healthIn, float speedIn, int targetIn = 1)
    {
        health = healthIn;
        speed = speedIn;
        target = targetIn;
    }


    void FixedUpdate()
    {

        if (target < TargetParentObject.transform.childCount)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetParentObject.transform.GetChild(target).position, speed*Time.deltaTime);
            if (transform.position == TargetParentObject.transform.GetChild(target).position)
            {
                target++;
            }
        }
        else
        {
            Destroy(gameObject);
            HealthManager.Instance.TakeDamage(health);
        }

    }


}
