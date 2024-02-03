using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralControl : MonoBehaviour
{
    public TriggerDetector[] triggers; // �洢���е�TriggerDetector�ű�����
    public GameObject prompt;

    public void Show(GameObject prompt)
    {
        //������ĳ�����弤����ǽ��ã�������prompt��Ҳ�����Ǹ�ͼ��
        //����ʱ���������������嶼����ã���������Ľű���������ܷ���
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
