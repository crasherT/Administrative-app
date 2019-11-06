using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<ItemContent> itemContents = new List<ItemContent>();

    public SaveData(HourList hourList)
    {
        itemContents = hourList.itemContentScripts;
    }
}
