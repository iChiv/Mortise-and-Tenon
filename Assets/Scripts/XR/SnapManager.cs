using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SnapManager : MonoBehaviour
{
    public int stage;
    
    public BlockPieces[] blockPieces1;
    public BlockPieces[] blockPieces2;
    public BlockPieces[] blockPieces3;
    public BlockPieces[] blockPieces4;
    public BlockPieces[] blockPieces5;
    public GameObject rewardVFX;
    public AudioClip rewardSfxClip;
    private AudioSource audioSource;
    // public GameObject winSignal;

    public GameObject Part1Template;
    public GameObject Part1targets;
    public GameObject Part1Blocks;
    public GameObject Part1Finished;
    
    public GameObject Part2Template;
    public GameObject Part2targets;
    public GameObject Part2Blocks;
    public GameObject Part2Finished;
    
    public GameObject Part3Template;
    public GameObject Part3targets;
    public GameObject Part3Blocks;
    public GameObject Part3Finished;
    
    public GameObject Part4Template;
    public GameObject Part4targets;
    public GameObject Part4Blocks;
    public GameObject Part4Finished;
    
    public GameObject Shield_finshed;

    public GameObject ShipTemplate;
    public GameObject ShipTargets;
    public GameObject ShipFinishedModuel;
    

    private FlyToPlayer flyToPlayer;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // if (stage == 1)
        // {
        //     EnableAllGrab();
        // }
        EnableAllGrab();
    }

    private void Update()
    {
        if (AreAllPiecesCorrectlyPositioned())
        {
            RewardAndProceed();
            stage += 1;
            EnableAllGrab();
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
            case 5:
                foreach (var piece in blockPieces5)
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
            case 5:
                ShipFinished();
                break;
            case 1:
                Part1Completed();
                break;
            case 2:
                Part2Completed();
                break;
            case 3:
                Part3Completed();
                break;
            case 4:
                Part4Completed();
                break;
            default:
                Debug.Log("level not set");
                break;
        }
    }

    public void Part1Completed()
    {
        Part1targets.SetActive(false);
        Part1Blocks.SetActive(false);
        Part1Template.SetActive(false);
        Part1Finished.SetActive(true);
        Part2Template.SetActive(true);
        Part2targets.SetActive(true);
        foreach (var piece in blockPieces2)
        {
            piece.GetComponent<FlyToPlayer>().EnableGrab();
        }
    }
    
    public void Part2Completed()
    {
        Part2targets.SetActive(false);
        Part2Blocks.SetActive(false);
        Part2Template.SetActive(false);
        Part2Finished.SetActive(true);
        Part3Template.SetActive(true);
        Part3targets.SetActive(true);
        foreach (var piece in blockPieces3)
        {
            piece.GetComponent<FlyToPlayer>().EnableGrab();
        }
    }
    
    public void Part3Completed()
    {
        Part3targets.SetActive(false);
        Part3Blocks.SetActive(false);
        Part3Template.SetActive(false);
        Part3Finished.SetActive(true);
        Part4Template.SetActive(true);
        Part4targets.SetActive(true);
        foreach (var piece in blockPieces4)
        {
            piece.GetComponent<FlyToPlayer>().EnableGrab();
        }
    }
    
    public void Part4Completed()
    {
        Part4targets.SetActive(false);
        Part4Blocks.SetActive(false);
        Part4Template.SetActive(false);
        Part4Finished.SetActive(true);
        Shield_finshed.SetActive(true);
        ShipTemplate.SetActive(true);
        ShipTargets.SetActive(true);
    }

    public void EnableAllGrab()
    {
        switch (stage)
        {
            case 1:
                foreach (var piece in blockPieces1)
                {
                    flyToPlayer = piece.GetComponent<FlyToPlayer>();
                    flyToPlayer.MoveToPlayer();
                    flyToPlayer.EnableGrab();
                }
                break;
            case 2:
                foreach (var piece in blockPieces2)
                {
                    flyToPlayer = piece.GetComponent<FlyToPlayer>();
                    flyToPlayer.MoveToPlayer();
                    flyToPlayer.EnableGrab();
                }
                break;
            case 3:
                foreach (var piece in blockPieces3)
                {
                    flyToPlayer = piece.GetComponent<FlyToPlayer>();
                    flyToPlayer.MoveToPlayer();
                    flyToPlayer.EnableGrab();
                }
                break;
            case 4:
                foreach (var piece in blockPieces4)
                {
                    flyToPlayer = piece.GetComponent<FlyToPlayer>();
                    flyToPlayer.MoveToPlayer();
                    flyToPlayer.EnableGrab();
                }
                break;
            case 5:
                break;
        }
        
    }

    public void ShipFinished()
    {
        ShipFinishedModuel.SetActive(true);
        ShipTemplate.SetActive(false);
        ShipTargets.SetActive(false);
        Shield_finshed.SetActive(false);
        Part1Finished.SetActive(false);
        Part2Finished.SetActive(false);
        Part3Finished.SetActive(false);
        Part4Finished.SetActive(false);
    }
}
