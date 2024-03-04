using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnapManager : MonoBehaviour
{
    public int stage;
    public BlockPieces[] blockPieces0;
    public BlockPieces[] blockPieces1;
    public BlockPieces[] blockPieces2;
    public BlockPieces[] blockPieces3;
    public BlockPieces[] blockPieces4;
    public GameObject rewardVFX;
    public AudioClip rewardSfxClip;
    private AudioSource audioSource;
    // public GameObject winSignal;
    public GameObject template;
    public GameObject targets;
    public GameObject blocks;
    public GameObject finished;

    public GameObject Part2Template;
    public GameObject Part2targets;
    public GameObject Part3Template;
    public GameObject Part3targets;
    public GameObject Part4Template;
    public GameObject Part4targets;
    public GameObject Shield_finshed;

    private FlyToPlayer flyToPlayer;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (stage == 1)
        {
            EnableAllGrab();
        }
    }

    private void Update()
    {
        if (AreAllPiecesCorrectlyPositioned())
        {
            stage += 1;
            switch (stage)
            {
                default:
                    break;
                case 2:
                    EnableAllGrab();
                    break;
                case 3:
                    EnableAllGrab();
                    break;
                case 4:
                    EnableAllGrab();
                    break;
            }
            RewardAndProceed();
        }
    }

    bool AreAllPiecesCorrectlyPositioned()
    {
        switch (stage)
        {
            case 1:
                foreach (var piece in blockPieces1)
                {
                    if (!piece.IsPositionedCorrectly)
                        return false;
                }
                break;
            case 2:
                foreach (var piece in blockPieces2)
                {
                    if (!piece.IsPositionedCorrectly)
                        return false;
                }
                break;
            case 3:
                foreach (var piece in blockPieces3)
                {
                    if (!piece.IsPositionedCorrectly)
                        return false;
                }
                break;
            case 4:
                foreach (var piece in blockPieces4)
                {
                    if (!piece.IsPositionedCorrectly)
                        return false;
                }
                break;
            case 0:
                foreach (var piece in blockPieces0)
                {
                    if (!piece.IsPositionedCorrectly)
                        return false;
                }
                break;
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
        Part2Template.SetActive(true);
        Part2targets.SetActive(true);
    }
    
    public void Part2Finished()
    {
        Part3Template.SetActive(true);
        Part3targets.SetActive(true);
    }
    
    public void Part3Finished()
    {
        Part4Template.SetActive(true);
        Part4targets.SetActive(true);
    }
    
    public void Part4Finished()
    {
        Shield_finshed.SetActive(true);
    }

    public void EnableAllGrab()
    {
        foreach (var piece in blockPieces1)
        {
            flyToPlayer = piece.GetComponent<FlyToPlayer>();
            flyToPlayer.EnableGrab();
        }
    }

    public void ShipFinished()
    {
        //Animation & SFX
    }
}
