using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourList : MonoBehaviour
{
    [Header("List")]
    public List<ItemContent> itemContentScripts = new List<ItemContent>();

    [Header("Item variables")]
    [SerializeField] GameObject item;
    [SerializeField] GameObject itemListContent;

    [Header("UI Elements")]
    [SerializeField] Text totalHoursText;

     public static HourList instance;

    void Awake()
    {
        instance = this;
        LoadList();
    }

    //adds a new element in the itemcontenscript list
    public void AddItemToList(string date, string shiftBegin, string shiftEnd, float hours, float breaks)
    {
        int listLength = itemContentScripts.Count;
        GameObject itemGO = Instantiate(item, itemListContent.transform);
        Item itemScript = itemGO.GetComponent<Item>();
        itemContentScripts.Add(new ItemContent(date, hours, breaks, shiftBegin, shiftEnd));
        itemScript.VariableSetter(itemContentScripts[listLength].DateGetter(), itemContentScripts[listLength].ShiftBeginGetter(), itemContentScripts[listLength].ShiftEndGetter(), itemContentScripts[listLength].HoursGetter(), itemContentScripts[listLength].BreaksGetter(),itemContentScripts[listLength]);
        SaveList();
        CalculateTotalHours();
    }

    public void DeleteItem(ItemContent item)
    {       
        itemContentScripts.Remove(item);
        CalculateTotalHours();
        SaveList();
    }

    void CalculateTotalHours()
    {
        float calculatedHours = 0;
        for (int i = 0; i < itemContentScripts.Count; i++)
        {
            calculatedHours = itemContentScripts[i].HoursGetter() + calculatedHours;
        }
        totalHoursText.text = "Total hours: " + calculatedHours;
    }

    void SaveList()
    {
        SaveLoadSystem.Save(this);
    }

    public void LoadList()
    {
        SaveData saveData = SaveLoadSystem.LoadData();
        itemContentScripts = saveData.itemContents;
        for (int i = 0; i < itemContentScripts.Count; i++)
        {
            GameObject itemGO = Instantiate(item, itemListContent.transform);
            Item itemScript = itemGO.GetComponent<Item>();
            itemScript.VariableSetter(itemContentScripts[i].DateGetter(), itemContentScripts[i].ShiftBeginGetter(), itemContentScripts[i].ShiftEndGetter(), itemContentScripts[i].HoursGetter(), itemContentScripts[i].BreaksGetter(), itemContentScripts[i]);
            CalculateTotalHours();
        }
    }
}
