using UnityEngine;

public class HealthManager : MonoBehaviour
{   
    public static HealthManager Instance;
    private int health;
    [SerializeField] int maxHealth = 100;

    private void Start()
    {
         health = maxHealth;
    }
    
    private void Awake()
    {
        Instance = Instance != null ? Instance : this;
    }

    public void SetHealth(int newHealthValue)
    {
        health = newHealthValue;
        
        HealthListener();
    }

    public void TakeDamage(int subtractHealthValue)
    {
        health -= subtractHealthValue;

        HealthListener();
    }
    
    private void HealthListener()
    {
        if (health <= 0)
        {
            //GAME OVER
        }
    }

}
