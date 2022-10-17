using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    private delegate void GameFinishHandler();
    private event GameFinishHandler GameFinish;

    private ScenesController scenesController;
    private static GameController instance;

    private void OnEnable()
    {
        instance = this;   
        scenesController = new ScenesController();
        GameFinish += ReloadCurrnetScene;
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

    public static Vector2 GetPlayerPosition
    {
        get
        {
            return instance.player.transform.position;
        }
    }
}
