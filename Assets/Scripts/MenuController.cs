using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject[] menus;

    //closes all menu screens and opens a menu if a proper menu name is given.
    public void OpenMenu(string menuName)
    {
        DisableAll();
        if (menuName == "")
        {
            Debug.LogError("No menu name string given");
        }
        else
        {
            for (int i = 0; i < menus.Length; i++)
            {
                if (menuName == menus[i].name)
                {
                    menus[i].SetActive(true);
                }
            }
        }
    }

    //closes the app
    public void CloseApp()
    {
        Application.Quit();
    }

    //disables all menu's so a new one can be enabled
    void DisableAll()
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(false);
        }
    }
}
