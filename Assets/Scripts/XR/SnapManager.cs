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

    public FadeObject Part1Template;
    public FadeObject Part1targets;
    public FadeObject Part1Blocks;
    public FadeObject Part1Finished;
    
    public FadeObject Part2Template;
    public FadeObject Part2targets;
    public FadeObject Part2Blocks;
    public FadeObject Part2Finished;
    
    public FadeObject Part3Template;
    public FadeObject Part3targets;
    public FadeObject Part3Blocks;
    public FadeObject Part3Finished;
    
    public FadeObject Part4Template;
    public FadeObject Part4targets;
    public FadeObject Part4Blocks;
    public FadeObject Part4Finished;
    
    public FadeObject Shield_finshed;

    public FadeObject ShipTemplate;
    public FadeObject ShipTargets;
    public FadeObject ShipFinishedModuel;
    

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
        Part1targets.FadeOutAndDisable();
        Part1Blocks.FadeOutAndDisable();
        Part1Template.FadeOutAndDisable();
        Part1Finished.EnableAndFadeIn();
        Part2Template.EnableAndFadeIn();
        Part2targets.EnableAndFadeIn();
        foreach (var piece in blockPieces2)
        {
            piece.GetComponent<FlyToPlayer>().EnableGrab();
        }
    }
    
    public void Part2Completed()
    {
        Part2targets.FadeOutAndDisable();
        Part2Blocks.FadeOutAndDisable();
        Part2Template.FadeOutAndDisable();
        Part2Finished.EnableAndFadeIn();
        Part3Template.EnableAndFadeIn();
        Part3targets.EnableAndFadeIn();
        foreach (var piece in blockPieces3)
        {
            piece.GetComponent<FlyToPlayer>().EnableGrab();
        }
    }
    
    public void Part3Completed()
    {
        Part3targets.FadeOutAndDisable();
        Part3Blocks.FadeOutAndDisable();
        Part3Template.FadeOutAndDisable();
        Part3Finished.EnableAndFadeIn();
        Part4Template.EnableAndFadeIn();
        Part4targets.EnableAndFadeIn();
        foreach (var piece in blockPieces4)
        {
            piece.GetComponent<FlyToPlayer>().EnableGrab();
        }
    }
    
    public void Part4Completed()
    {
        Part4targets.FadeOutAndDisable();
        Part4Blocks.FadeOutAndDisable();
        Part4Template.FadeOutAndDisable();
        Part4Finished.EnableAndFadeIn();
        Shield_finshed.EnableAndFadeIn();
        ShipTemplate.EnableAndFadeIn();
        ShipTargets.EnableAndFadeIn();
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
        ShipFinishedModuel.EnableAndFadeIn();
        ShipTemplate.FadeOutAndDisable();
        ShipTargets.FadeOutAndDisable();
        Shield_finshed.FadeOutAndDisable();
        Part1Finished.FadeOutAndDisable();
        Part2Finished.FadeOutAndDisable();
        Part3Finished.FadeOutAndDisable();
        Part4Finished.FadeOutAndDisable();
    }
}
