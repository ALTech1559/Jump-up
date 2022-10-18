using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class UITestsController : MonoBehaviour
{
    [SerializeField] private MovementController player;
    [SerializeField] private TMP_Text jumpsCountText;
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        player.updateJumpsCount += UpdateJumpsCount;
        GameController.UpdateScoreText += UpdateScore;
    }

    private void OnDisable()
    {
        player.updateJumpsCount -= UpdateJumpsCount;
        GameController.UpdateScoreText -= UpdateScore;
    }

    private void UpdateJumpsCount(int jumpsCount)
    {
        jumpsCountText.text = jumpsCount.ToString();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
