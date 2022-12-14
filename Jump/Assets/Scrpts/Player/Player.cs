using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(MovementController))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    private MovementController movementController;

    private void Start()
    {
        movementController = GetComponent<MovementController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IEnemy>() != null)
        {
            gameController.FinishGame();
        }

        JumpBonus jumpBonus;

        if (collision.gameObject.TryGetComponent<JumpBonus>(out jumpBonus))
        {
            movementController.CurrentJumpsCount += jumpBonus.GetJumpsCount;
            movementController.UpdateJumpsCountInvoke();
            jumpBonus.DeleteMyself();
        }

        CoinBonus coinBonus;
        if (collision.gameObject.TryGetComponent<CoinBonus>(out coinBonus))
        {
            GameController.Score += coinBonus.GetCoinsCount;
            coinBonus.DeleteMyself();
        }
    }
}
