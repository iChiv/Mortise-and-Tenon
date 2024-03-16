using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public BlockPieces[] BlockPiecesArray;

    public GameObject VFX;

    public AudioClip SFX;

    public CanvasGroup titleCanvasGroup;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        titleCanvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (BlocksInPosition())
        {
            //All FX need to be less than invoke delay
            audioSource.PlayOneShot(SFX);
            Instantiate(VFX, transform.position, Quaternion.identity);
            titleCanvasGroup.DOFade(1, 2f).OnComplete(() => { // 使用DOTween使标题渐显
                Invoke(nameof(LoadMainScene), 2f); // 渐显完成后等待2秒加载主游戏场景
            });
        }
    }

    bool BlocksInPosition()
    {
        foreach (var block in BlockPiecesArray)
        {
            if (!block.IsPositionedCorrectly)
                return false;
        }
        return true;
    }

    void LoadMainScene()
    {
        SceneManager.LoadScene("Game");
    }
}
