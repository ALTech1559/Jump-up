using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    internal enum HardMode
    {
        Easy, 
        Medium, 
        Hard
    }

    [Header("Hard mode ranging")]
    [SerializeField] private int mediumLowRange;
    [SerializeField] private int hardLowRange;

    [Header("Score settings")]
    [SerializeField] private float scoreChangingTiming;
    [SerializeField] private int scoreChangingValue;

    [Header("Player")]
    [SerializeField] private Player player;
    private delegate void GameFinishHandler();
    private event GameFinishHandler GameFinish;
    internal delegate void UpdateScoreTextHandler(int score);
    internal static event UpdateScoreTextHandler UpdateScoreText;

    private ScenesController scenesController;
    private static GameController instance;
    private int score = 0;

    private HardMode hardMode;

    private void OnEnable()
    {
        hardMode = HardMode.Easy;
        instance = this;   
        scenesController = new ScenesController();
        GameFinish += ReloadCurrnetScene;
        StartCoroutine(UpdateScore());
    }

    internal void FinishGame()
    {
        GameFinish.Invoke();
    }

    private void ReloadCurrnetScene()
    {
        scenesController.ReloadCurrnetScene();
    }

    private void OnDisable()
    {
        GameFinish -= ReloadCurrnetScene;
    }

    private IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(scoreChangingTiming);
            score += scoreChangingValue;
            RangeHardMode();
            UpdateScoreText.Invoke(score);
        }
    }

    private void RangeHardMode()
    {
        if (score < mediumLowRange)
        {
            hardMode = HardMode.Easy;
        }
        else if (score < hardLowRange)
        {
            hardMode = HardMode.Medium;
        }
        else
        {
            hardMode = HardMode.Hard;
        }
    }

    internal static Vector2 GetPlayerPosition
    {
        get
        {
            return instance.player.transform.position;
        }
    }

    internal static int Score
    {
        get
        {
            return instance.score;
        }
        set
        {
            instance.score = value;
            instance.RangeHardMode();
            UpdateScoreText.Invoke(instance.score);
        }
    }

    internal static HardMode GameMode
    {
        get
        {
            return instance.hardMode;
        }
    }
}
