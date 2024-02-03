using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralControl : MonoBehaviour
{
    public TriggerDetector[] triggers; // 存储所有的TriggerDetector脚本引用
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



    void Update()
    {
        if (AreAllInTrigger())
        {
            Debug.Log("Correct");
            Show(prompt);
        }
    }

    bool AreAllInTrigger()
    {
        foreach (var trigger in triggers)
        {
            if (!trigger.isInTrigger)
                return false;
                Hide(prompt);
        }
        return true;
    }
}
