using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ChangeSceneAfterSomeTime : MonoBehaviour
{
    public int waitTime = 3;

    [Scene]
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
