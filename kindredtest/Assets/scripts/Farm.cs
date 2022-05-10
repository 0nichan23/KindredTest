using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public static Farm Instance;

    public int Money;

    public readonly List<Food> food = new List<Food>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Money += 1000;
        for (int i = 0; i < 10; i++)
        {
            BuyFood(true);
            BuyFood(false);
        }
        UiManager.Instance.UpdateTexts();
    }
    public bool CheckFoodaAvailabilty(Animal animal)
    {
        if (animal.Diet == Diet.Omnivore && food.Count != 0)
        {
            return true;
        }

        foreach (var item in food)
        {
            if (item.diet == animal.Diet)
            {
                return true;
            }
        }
        return false;
    }

    public void Feed(Animal animal)
    {
        Diet dietofchoice;

        switch (animal.Diet)
        {
            case Diet.Herbivore:
                dietofchoice = Diet.Herbivore;
                break;
            case Diet.Carnivore:
                dietofchoice = Diet.Carnivore;
                break;
            case Diet.Omnivore:
                dietofchoice = Diet.Omnivore;
                break;
            default:
                dietofchoice = Diet.Omnivore;
                break;
        }

        if (dietofchoice == Diet.Omnivore)
        {
            food.RemoveAt(0);
            UiManager.Instance.UpdateTexts();
            return;
        }


        foreach (var item in food)
        {
            if (item.diet == dietofchoice)
            {
                food.Remove(item);
                return;
            }
        }
        UiManager.Instance.UpdateTexts();
    }


    public void BuyFood(bool b)
    {
        if (Money >= 10)
        {
            switch (b)
            {
                case true:
                    food.Add(new Leaves());
                    break;
                case false:
                    food.Add(new Meat());
                    break;
            }
            Money -= 10;
        }
        UiManager.Instance.UpdateTexts();

    }

    public void SellStuff()
    {
        Money += 15;
        UiManager.Instance.UpdateTexts();
    }
}
