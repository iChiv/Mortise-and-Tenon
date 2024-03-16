using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject about;
    [SerializeField] private GameObject restartDialog;
    [SerializeField] private GameObject restartYesButton;
    [SerializeField] private GameObject restartNoButton;

    void Start()
    {
        ShowTutorial(); 
    }
    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            menu.SetActive(!menu.activeSelf);
            if (menu.activeSelf)
            {
                ShowTutorial(); 
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TutorialButton()
    {
        ShowTutorial();
    }

    public void RestartButton()
    {
        restartDialog.SetActive(true); // 显示重新开始对话框
    }

    public void AboutUs()
    {
        tutorial.SetActive(false);
        about.SetActive(true);
        restartDialog.SetActive(false);
    }

    public void OnRestartYesClicked()
    {
        Restart();
    }

    public void OnRestartNoClicked()
    {
        restartDialog.SetActive(false);
        // 根据需要，您可以在这里重新显示教程或其他界面
    }

    private void ShowTutorial()
    {
        tutorial.SetActive(true);
        about.SetActive(false);
        restartDialog.SetActive(false);
    }
}
