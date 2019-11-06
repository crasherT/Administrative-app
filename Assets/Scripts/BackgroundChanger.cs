using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{

    public Image[] backgrounds;

    void Start()
    {
        ChangeBackground();
    }

    void ChangeBackground()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].gameObject.SetActive(false);
        }
        int randomNumber = Random.Range(0, backgrounds.Length);
        backgrounds[randomNumber].gameObject.SetActive(true);
    }
}
