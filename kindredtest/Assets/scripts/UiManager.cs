using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public TextMeshProUGUI Moneytmpro;
    public TextMeshProUGUI HFood;
    public TextMeshProUGUI CFood;

    public DescriptionScreen DescriptionScreen;


    public Image Meat;
    public Image Leaves;
    public void UpdateTexts()
    {
        int camount = 0;
        int hamount = 0;
        Moneytmpro.text = Farm.Instance.Money.ToString();
        foreach (var item in Farm.Instance.food)
        {
            if (item.diet == Diet.Carnivore)
            {
                camount++;
            }
            else
            {
                hamount++;
            }
        }

        HFood.text = hamount.ToString();
        CFood.text = camount.ToString();

    }


    public void ToggleDescription()
    {
        if (DescriptionScreen.gameObject.activeSelf)
        {
            DescriptionScreen.gameObject.SetActive(false);
        }
        else
        {
            DescriptionScreen.gameObject.SetActive(true);
        }
    }

}
