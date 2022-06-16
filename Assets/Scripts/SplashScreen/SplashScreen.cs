using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    [SerializeField]
    private AudioClip upSound;

    [SerializeField]
    private AudioClip downSound;

    public void PlayUpSound()
    {
        Debug.Log("PlayUpSound");
    }

    public void PlayDownSound()
    {
        Debug.Log("PlayDownSound");
    }
}
