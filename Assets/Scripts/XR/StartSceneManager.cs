using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public BlockPieces[] BlockPiecesArray;

    public GameObject VFX;

    public AudioClip SFX;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BlocksInPosition())
        {
            //All FX need to be less than invoke delay
            audioSource.PlayOneShot(SFX);
            Instantiate(VFX, transform.position, Quaternion.identity);
            Invoke(nameof(LoadMainScene),2f);
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
