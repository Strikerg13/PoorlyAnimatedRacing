using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    /// How much an individual coin is worth.
    public int value;

    public float rotationSpeed;

    void Update()
    {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }

    // Add a coin to the player's total, then delete.
    void OnTriggerEnter()
    {
        
        GameObject.Find("GameManager").GetComponent<MoneyDisplay>().addCoins(value);

        Destroy(gameObject);
    }

}
