using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAfterSomeTime : MonoBehaviour
{
    public int waitTime = 3;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneLoader.Instance.LoadScene (sceneName);
    }
}
