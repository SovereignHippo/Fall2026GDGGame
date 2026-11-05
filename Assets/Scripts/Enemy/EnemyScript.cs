using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MovementScript))]
public class EnemyScript : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] float speed;
    [SerializeField] GameObject deathSpawnling;
    [SerializeField] int numberOfSpawnlingsToSpawn = 1;

    private int target = 1;
    private GameObject TargetParentObject;

    MovementScript movementScript;

    void SetTarget(int targetIn)
    {
        target = targetIn;
    }
    void Start()
    {
        TargetParentObject = GameObject.Find("PathfindingObjects");

        movementScript = GetComponent<MovementScript>();
        movementScript.Setup(health, speed, target);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Figure this out later
    }

    //Folowing is all stuff for future tower aim priority
    public double DistanceToEnd()
    {
        target = movementScript.GetTargetInt();
        double distanceToTarget = Vector2.Distance(transform.position, TargetParentObject.transform.GetChild(target).position);
        double distance;
        switch (target) // Since distance is for target prio, the actual amout doesnt matter, 
                        // going down by 20 makes sure that the targets aren't seleceted in the wrong order
        {
            case 1:
                distance = distanceToTarget + 100;
                break;
            case 2:
                distance = distanceToTarget + 80;
                break;
            case 3:
                distance = distanceToTarget + 60;
                break;
            case 4:
                distance = distanceToTarget + 40;
                break;
            default:
                distance = distanceToTarget; // Unneeded but it stops it from being mad at me
                break;
        }

        return distance;
    }
    public double DistanceToPoint(Transform point)
    {
        return Vector2.Distance(transform.position, point.position);
    }
    public int GetHealth()
    {
        return health;
    }

    public void EnemyHit()
    {
        float spacing = 0.1f;
        target = movementScript.GetTargetInt();
        bool thereIsAChild = deathSpawnling != null;
        if (thereIsAChild)
        {
            for (int i = 0; i < numberOfSpawnlingsToSpawn; i++)
            {
                Vector3 offset = i * spacing * transform.right; // need to change to be dynamic based on movement dirrecntion
                GameObject temp = Instantiate(deathSpawnling, transform.position + offset, Quaternion.identity);
                EnemyScript enemyScript = temp.GetComponent<EnemyScript>();
                enemyScript.SetTarget(target);
            }
        }
        Destroy(gameObject);
    }
}
