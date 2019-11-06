using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AddNew : MonoBehaviour
{
    [Header("Date")]
    [SerializeField]string date;
    [SerializeField]Toggle useCurrentDateToggle;

    [SerializeField] Dropdown day;
    [SerializeField] Dropdown month;
    [SerializeField] Dropdown year;

    [Header("Hours")]
    [SerializeField] Dropdown beginInput;
    [SerializeField] Dropdown endInput;
    [SerializeField] Dropdown breakInput;
    [Space]
    public float totalHoursWorked;
    public float breakTime;


    void Update()
    {
        CheckToggleState();
    }

    //Turns the dropdowns on and off depending on the state of the UseCurrentDayToggle.
    void CheckToggleState()
    {
        if (useCurrentDateToggle.isOn == true)
        {
            day.interactable = false;
            month.interactable = false;
            year.interactable = false;
        }
        else
        {
            day.interactable = true;
            month.interactable = true;
            year.interactable = true;
        }
    }

    //this script will save all the input from the add new screen.
    public void SaveInput()
    {
        SaveDate();
        totalHoursWorked = ShiftCounter();
        breakTime = CalculateBreaks();
        totalHoursWorked -= breakTime;

        //rework calculations V Temporary fix V
        if(totalHoursWorked <= 0)
        {
            totalHoursWorked = 0;
        }

        HourList listScript = HourList.instance;
        listScript.AddItemToList(date, beginInput.options[beginInput.value].text, endInput.options[endInput.value].text, totalHoursWorked, breakTime);
    }

    //saves the month variables.
    void SaveDate()
    {
        if (useCurrentDateToggle.isOn == true)
        {
            date = DateTime.Now.ToShortDateString();
        }
        else
        {
            date = day.options[day.value].text + "/" + month.options[month.value].text + "/" + year.options[year.value].text;
        }
    }

    //Calculates the break amount
    float CalculateBreaks()
    {
        return float.Parse(breakInput.options[breakInput.value].text);
    }

    //takes the input of the dropdowns and counts the hours worked.
    float ShiftCounter()
    {
        DateTime beginTime = DateTime.Parse(beginInput.options[beginInput.value].text);
        DateTime endTime = DateTime.Parse(endInput.options[endInput.value].text);
        TimeSpan hoursWorked = endTime - beginTime;

        float totalMinutesWorked = (float)hoursWorked.TotalMinutes;
        float totalHours = totalMinutesWorked / 60;

        return totalHours;
    }
}
