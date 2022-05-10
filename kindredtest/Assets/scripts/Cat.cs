using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{

    public override void MyStart()
    {
        Diet = Diet.Carnivore;
        height = Random.Range(10,17);
        weight = Random.Range(4,17);
        age = Random.Range(1,16);

    }

    public override void GenerateProfit()
    {
        Farm.Instance.BuyFood(false);
    }
}
