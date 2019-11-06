using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [Header("Information thats needed")]
    [SerializeField] bool isPaid;
    ItemContent itemContent;

    [Header("Text UI elements")]
    [SerializeField] Text dateText;
    [SerializeField] Text breaksText;
    [SerializeField] Text shiftText;
    [SerializeField] Text hoursText;

    [Header("interactable UI elements")]
    [SerializeField] Toggle paidToggle;
    [SerializeField] Button deleteButton;

    void Update()
    {
        DeleteButtonActivatorChecker();
    }

    public void VariableSetter(string date, string shiftBegin, string shiftEnd, float hours, float breaks, ItemContent itemContent)
    {
        dateText.text = date;
        breaksText.text = "Breaks: " + breaks;
        hoursText.text = "Hours: " + hours;
        shiftText.text = shiftBegin + " / " + shiftEnd;
        this.itemContent = itemContent;
    }

    //checks whether or not the item has been paid or not
    void DeleteButtonActivatorChecker()
    {
        switch (paidToggle.isOn)
        {
            case false:
                deleteButton.interactable = false;
                break;

            case true:
                deleteButton.interactable = true;
                break;

            default:
                Debug.LogError("This should never be default (Item Script)");
                break;
        }
    }

    public void Toggle()
    {
        SoundManager.instance.PlayClickSFX();
    }

    public void DeleteButton()
    {
        HourList.instance.DeleteItem(itemContent);
        SoundManager.instance.PlayDeleteSFX();
        Destroy(gameObject);
    }
}
