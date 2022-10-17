using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class UITestsController : MonoBehaviour
{
    [SerializeField] private string jumpsCountBaseString;
    [SerializeField] private MovementController player;
    [SerializeField] private TMP_Text jumpsCountText;

    private void OnEnable()
    {
        player.updateJumpsCount += UpdateJumpsCount;
    }

    private void OnDisable()
    {
        player.updateJumpsCount -= UpdateJumpsCount;
    }

    private void UpdateJumpsCount(int jumpsCount)
    {
        jumpsCountText.text = jumpsCountBaseString + " " + jumpsCount.ToString();
    }
}
