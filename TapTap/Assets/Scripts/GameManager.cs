using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameStatus GameStatus { set; get; }

    private void Awake()
    {
        GameObject.Instantiate(Resources.Load("UI/readyUI"), Vector3.zero, Quaternion.identity, UI.Root.transform);

        Message.AddListener<GameStatusMessage>(OnGameStatusChange);
    }

    private void OnGameStatusChange(GameStatusMessage msg)
    {
        if (GameStatus == msg.Status)
            return;
        if (msg.Status == GameStatus.GameExit)
            return; /* TODO: ExitGame */

        GameStatus = msg.Status;
        if (msg.Status == GameStatus.GameReady)
        {
            Instantiate(Resources.Load("UI/readyUI"), Vector3.zero, Quaternion.identity, UI.Root.transform);
            GameBoardController[] boards = GameObject.FindObjectsOfType<GameBoardController>();
            foreach (GameBoardController board in boards)
            {
                Destroy(board.gameObject);
            }
            JellyFishController[] ctrls = FindObjectsOfType<JellyFishController>();
            foreach (JellyFishController fish in ctrls)
            {
                Destroy(fish.gameObject);
            }
        }
        else if (msg.Status == GameStatus.GamePlaying)
        {
            GameBoardController[] boards = GameObject.FindObjectsOfType<GameBoardController>();
            if (boards.Length > 0)
            {
                boards[0].Restart();
            }
            else
            {
                GameBoardModel model = new GameBoardModel();
                model.JellyFishs = new ModelRefs<JellyFishModel>();
                GameBoardController ctrl = Controller.Instantiate<GameBoardController>("UI/gameBoard", model);
            }
        }
        else if (msg.Status == GameStatus.GameOver)
        {
            Instantiate(Resources.Load("UI/gameOver"), Vector3.zero, Quaternion.identity, UI.Root.transform);
        }
    }
}
