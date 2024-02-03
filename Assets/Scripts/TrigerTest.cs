using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerTest : MonoBehaviour
{
    public GameObject prompt;

    public void Show(GameObject prompt)
    {
        //用来将某个物体激活或是禁用（这里是prompt，也就是那个图标
        //禁用时这个物体和其子物体都会禁用，包括上面的脚本，在这里很方便
        prompt.SetActive(true);
    }
    public void Hide(GameObject prompt)
    {

        prompt.SetActive(false);
    }

    void Start()
    {
        Hide(prompt);

    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Correct");
        Show(prompt);
    }

    void OnTriggerExit(Collider other)
    {

        Debug.Log("Correct");
        Hide(prompt);
    }

}

