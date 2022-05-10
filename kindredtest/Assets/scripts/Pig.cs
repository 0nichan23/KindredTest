using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : Animal
{
    public override void MyStart()
    {
        Diet = Diet.Omnivore;
        height = Random.Range(20, 36);
        weight = Random.Range(100, 701);
        age = Random.Range(1, 21);

    }

    public override void GenerateProfit()
    {
        Farm.Instance.BuyFood(true);
    }

}
