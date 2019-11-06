using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource delete;
    [SerializeField] AudioSource confirm;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayClickSFX()
    {
        click.Play();
    }

    public void PlayDeleteSFX()
    {
        delete.Play();
    }

    public void PlayConfirmSFX()
    {
        confirm.Play();
    }
}
