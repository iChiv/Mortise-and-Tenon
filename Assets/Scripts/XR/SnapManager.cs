using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapManager : MonoBehaviour
{
    public BlockPieces[] blockPieces;
    public GameObject rewardVFX;
    public AudioClip rewardSfxClip;
    private AudioSource audioSource;
    public GameObject winSignal;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (AreAllPiecesCorrectlyPositioned())
        {
            RewardAndProceed();
        }
    }

    bool AreAllPiecesCorrectlyPositioned()
    {
        foreach (var piece in blockPieces)
        {
            if (!piece.isPositionedCorrectly)
                return false;
        }

        return true;
    }

    void RewardAndProceed()
    {
        if (rewardVFX != null)
        {
            Instantiate(rewardVFX, transform.position, Quaternion.identity);
        }

        if (rewardSfxClip != null)
        {
            audioSource.PlayOneShot(rewardSfxClip);
        }
        
        NextStage();
    }

    void NextStage()
    {
        winSignal.SetActive(true);
        //Do sth.!
    }
}
