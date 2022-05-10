using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescriptionScreen : MonoBehaviour
{
    public TextMeshProUGUI Height;
    public TextMeshProUGUI Weight;
    public TextMeshProUGUI Age;
    public TextMeshProUGUI Activity;


    public Slider HungerBar;
    public Slider ActivityBar;


    public Image FoodType;



    public void SetUpOrUpdateAnimal(Animal animal)
    {

        HungerBar.maxValue = 10;
        HungerBar.value = animal.currentHunger;
        Height.text = animal.height.ToString() + "inches";
        Weight.text = animal.weight.ToString() + "lbs";
        Age.text = animal.age.ToString() + "Years old";
        UiManager.Instance.UpdateTexts();
    }

    public IEnumerator ActivityStatus(int time, string activity, Animal animal)
    {
        animal.busy = true;
        Activity.text = activity;
        ActivityBar.maxValue = time;
        ActivityBar.value = 0;

        for (int i = 0; i < time; i++)
        {
            yield return new WaitForSeconds(1f);
            ActivityBar.value++;
        }
        Activity.text = "";
        animal.busy = false;
    }


}
