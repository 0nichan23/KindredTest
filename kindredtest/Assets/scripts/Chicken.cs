using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Animal
{

    public override void MyStart()
    {
        Diet = Diet.Herbivore;
        height = Random.Range(10, 15);
        weight = Random.Range(2, 6);
        age = Random.Range(1, 3);

    }
    public override void GenerateProfit()
    {
        Farm.Instance.SellStuff();
    }
}
