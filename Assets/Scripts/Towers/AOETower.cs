using System.Collections.Generic;
using UnityEngine;

public class AOETower : BaseTower
{

    [SerializeField] private int numberOfProjectiles;

    public override void Attack()
    {
        if (fireRateTimer > fireRateCooldown)
        {
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                
                float angleToFire = i * (360 / numberOfProjectiles);
                GameObject temp = Instantiate(projectile, transform.position, Quaternion.identity); //Spawn projectile
                BasicProjectile tempScript = temp.GetComponent<BasicProjectile>();
                tempScript.SetTarget(AngleToUnitVector(angleToFire) + transform.position, transform); //Give projectile target's positions
                Debug.Log(AngleToUnitVector(angleToFire));
                tempScript.SetRange(range); //Pass through the range
                
            }
            fireRateTimer = 0; //Reset Timer
        }
    }

    public override void LookAtTarget()
    {
        //DO NOTHING
    }
}
