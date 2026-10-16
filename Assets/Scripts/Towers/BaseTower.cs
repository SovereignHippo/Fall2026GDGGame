using Mono.Cecil;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class BaseTower : MonoBehaviour
{

    [SerializeField] private int sellValue;
    [SerializeField] private protected float range;
    [SerializeField] private protected GameObject projectile;
    [SerializeField] private protected float fireRateCooldown;
    [SerializeField] private LayerMask enemyLayer;

    private protected Transform currentTargetTransform;
    private protected float fireRateTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireRateTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentTargetTransform == null)
        {
            //Debug.Log("Target Lost!");
            FindTarget();
        }else
        {
            if ((currentTargetTransform.position - transform.position).magnitude > range)
            {
                //If target goes out of range find a new target
                currentTargetTransform = null;
            }
            else
            {
                Attack();
                LookAtTarget();
            }

                
        }

        fireRateTimer += Time.deltaTime; //Always increase the timer for cooldown
    }

    public virtual void LookAtTarget()
    {
        float angle = Mathf.Atan2((currentTargetTransform.position.y - transform.position.y), (currentTargetTransform.position.x - transform.position.x)); //Calculate angle direction towards enemy
        angle = angle * (180 / Mathf.PI ); // convert to degrees
        transform.rotation = Quaternion.Euler(0, 0, (angle + 90 + 180));//set roation
        
    }

    public virtual void Attack()
    {
        if (fireRateTimer > fireRateCooldown)
        {
            GameObject temp = Instantiate(projectile, transform.position, Quaternion.identity); //Spawn projectile
            BasicProjectile tempScript = temp.GetComponent<BasicProjectile>();
            tempScript.SetTarget(currentTargetTransform.position, transform); //Give projectile target's positions
            tempScript.SetRange(range); //Pass through the range

            fireRateTimer = 0; //Reset Timer
        }

    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2)transform.position, 0f, enemyLayer);

        if (hits.Length > 0)
        {
            currentTargetTransform = hits[0].transform;
            //Debug.Log("Target Aquired!");
        }
    }

    public Vector3 AngleToUnitVector(float angleInDegrees)
    {
        float radians = angleInDegrees * (float)(Math.PI / 180.0);
        // In Unity, use: float radians = angleInDegrees * Mathf.Deg2Rad;

        return new Vector3(
            (float)Math.Cos(radians),
            (float)Math.Sin(radians),
            0
        );
    }

}
