using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private float scoreChangingTiming;
    [SerializeField] private int scoreChangingValue;
    [SerializeField] private Player player;
    private delegate void GameFinishHandler();
    private event GameFinishHandler GameFinish;
    internal delegate void UpdateScoreTextHandler(int score);
    internal static event UpdateScoreTextHandler UpdateScoreText;

    private ScenesController scenesController;
    private static GameController instance;
    private int score = 0;

    private void OnEnable()
    {
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
            UpdateScoreText.Invoke(score);
        }
    }

    public static Vector2 GetPlayerPosition
    {
        get
        {
            return instance.player.transform.position;
        }
    }
}
