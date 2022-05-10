using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Diet
{
    Herbivore,
    Carnivore,
    Omnivore
}

public abstract class Animal : MonoBehaviour, IPointerDownHandler
{

    new string name;


    public int age;


    public float height;


    public float weight;

    public Diet Diet;

    int maxHunger;
    public int currentHunger;

    string Activity;

    int counter;

    public bool busy;
    private void Start()
    {
        maxHunger = 10;
        currentHunger = maxHunger;
        MyStart();
        StartCoroutine(GainHunger());
        RollNextAction();
    }

    public abstract void MyStart();
    public void Eat()
    {
        if (Farm.Instance.CheckFoodaAvailabilty(this))
        {
            currentHunger += 2;
            if (currentHunger > maxHunger)
            {
                currentHunger = maxHunger;
            }
            Farm.Instance.Feed(this);
        }
    }

    IEnumerator Walking()
    {
        Activity = "Walking";
        StartCoroutine(UiManager.Instance.DescriptionScreen.ActivityStatus(5, Activity, this));
        yield return new WaitUntil(() => busy == false);
        RollNextAction();

    }

    IEnumerator Eating()
    {
        Activity = "Eating";
        Eat();
        StartCoroutine(UiManager.Instance.DescriptionScreen.ActivityStatus(5, Activity, this));
        yield return new WaitUntil(() => busy == false);
        RollNextAction();

    }

    IEnumerator Sleeping()
    {
        Activity = "Sleeping";
        StartCoroutine(UiManager.Instance.DescriptionScreen.ActivityStatus(5, Activity, this));
        yield return new WaitUntil(() => busy == false);
        RollNextAction();
    }

    IEnumerator GainHunger()
    {
        while (true)
        {
            currentHunger--;
            if (currentHunger < 0)
            {
                currentHunger = 0;
            }
            yield return new WaitForSeconds(25f);

        }
    }

    public void RollNextAction()
    {
        counter++;
        if (counter >= 3)
        {
            age++;
            counter = 0;
            GenerateProfit();
        }
        if (currentHunger < 5)
        {
            StartCoroutine(Eating());
            UiManager.Instance.DescriptionScreen.SetUpOrUpdateAnimal(this);
            return;
        }
        switch (Random.Range(0, 3))
        {
            case 0:
                StartCoroutine(Walking());
                break;
            case 1:
                StartCoroutine(Sleeping());
                break;
            case 2:
                StartCoroutine(Eating());
                break;
            default:
                break;
        }
        UiManager.Instance.DescriptionScreen.SetUpOrUpdateAnimal(this);
    }

    public abstract void GenerateProfit();

    

    public void OnPointerDown(PointerEventData eventData)
    {
        UiManager.Instance.ToggleDescription();
        UiManager.Instance.DescriptionScreen.SetUpOrUpdateAnimal(this);
    }
}
