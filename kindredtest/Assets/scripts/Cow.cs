using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Animal
{

    public override void MyStart()
    {
        Diet = Diet.Herbivore;
        height = Random.Range(45, 61);
        weight = Random.Range(1000, 4001);
        age = Random.Range(1, 21);

    }
    public override void GenerateProfit()
    {
        Farm.Instance.SellStuff();
    }

}
