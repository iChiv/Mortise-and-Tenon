using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerTest : MonoBehaviour
{
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

