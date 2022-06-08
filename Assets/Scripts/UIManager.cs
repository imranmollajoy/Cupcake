using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // create singelton
    public static UIManager Instance;

    [SerializeField]
    private GameObject downButton;

    public GameObject DownButton
    {
        get { return downButton; }
    }

    void Awake()
    {
      if(Instance == null)
      {
        Instance = this;
      }
      else
      {
        Destroy(gameObject);
      }
    }
}
