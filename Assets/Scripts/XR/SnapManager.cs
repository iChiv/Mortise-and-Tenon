using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapManager : MonoBehaviour
{
    public int stage;
    public BlockPieces[] blockPieces;
    public GameObject rewardVFX;
    public AudioClip rewardSfxClip;
    private AudioSource audioSource;
    // public GameObject winSignal;
    public GameObject template;
    public GameObject targets;
    public GameObject blocks;
    public GameObject finished;

    public GameObject Part2All;
    public GameObject Part3All;
    public GameObject Part4All;
    public GameObject Shield_finshed;
    

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
            if (!piece.IsPositionedCorrectly)
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
        switch (stage)
        {
            case 0:
                ShipFinished();
                break;
            case 1:
                Part1Finished();
                PartFinished();
                break;
            case 2:
                PartFinished();
                Part2Finished();
                break;
            case 3:
                PartFinished();
                Part3Finished();
                break;
            case 4:
                PartFinished();
                Part4Finished();
                break;
            default:
                Debug.Log("level not set");
                break;
        }
    }

    public void PartFinished()
    {
        template.SetActive(false); // fade out nothing then disable
        targets.SetActive(false); // fade out nothing then disable
        blocks.SetActive(false); // fade out nothing then disable
        finished.SetActive(true); // fade in
    }

    public void Part1Finished()
    {
        Part2All.SetActive(true);
    }
    
    public void Part2Finished()
    {
        Part3All.SetActive(true);
    }
    
    public void Part3Finished()
    {
        Part4All.SetActive(true);
    }
    
    public void Part4Finished()
    {
        Shield_finshed.SetActive(true);
    }

    public void ShipFinished()
    {
        //Animation & SFX
    }
}
