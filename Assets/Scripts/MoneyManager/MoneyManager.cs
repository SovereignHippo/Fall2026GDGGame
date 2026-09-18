using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [SerializeField] int startingMoney = 100000000;
    private int balance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        balance = startingMoney;
    }

    void Awake()
    {
        Instance = Instance != null ? Instance : this;
    }

    public void SetBalance(int newBal)
    {
        balance = newBal;
    }
    
    public void AddBalance(int addAmount)
    {
        balance += addAmount;
    }

    public bool CanAfford(int cost)
    {
        return 0 <= (balance - cost);
    }
}
