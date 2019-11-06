using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemContent
{
    string date;
    float hours;
    float breaks;
    string shiftBegin;
    string shiftEnd;

    public ItemContent(string date, float hours, float breaks, string shiftBegin, string shiftEnd)
    {
        this.date = date;
        this.hours = hours;
        this.breaks = breaks;
        this.shiftBegin = shiftBegin;
        this.shiftEnd = shiftEnd;
    }

    public string DateGetter()
    {
        return date;
    }
    public string ShiftBeginGetter()
    {
        return shiftBegin;
    }
    public string ShiftEndGetter()
    {
        return shiftEnd;
    }
    public float HoursGetter()
    {
        return hours;
    }
    public float BreaksGetter()
    {
        return breaks;
    }
}
