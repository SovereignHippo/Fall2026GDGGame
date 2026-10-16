using System;
using System.Net.Http.Headers;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private int target = 1;
    private GameObject TargetParentObject;
    [SerializeField] float speed = 1.0f;
    [SerializeField] int health = 1;

    void Start()
    {
        TargetParentObject = GameObject.Find("PathfindingObjects");
    }

    public void SetTargetInt(int targetInt)
    {
        target = targetInt;
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
