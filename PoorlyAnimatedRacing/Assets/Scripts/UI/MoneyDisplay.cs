using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    /// How many coins the player has collected.
    public int money = 1;
    /// Textbox that displays the player's money.
    public Text txtMoneyDisplay;


    /// Reset the player's money.
    void initializeMoney()
    {
        money = 1;
        displayMoney();
    }

    /// Increase the total amount of money by a specified amount.
    public void addCoins(int number)
    {
        money += number;

        displayMoney();
    }

    /// Decrease the total amount of money by a specified amount.
    public bool removeCoins(int number)
    {
        if ((money - number) >= 0)
        {
            money -= number;
            displayMoney();
            return true;
        }
        else
        {
            return false;
        }
    }

    /// Display the amount of money the player has.
    void displayMoney()
    {
        txtMoneyDisplay.text = money.ToString();
    }
}
