using UnityEngine;
using System.Collections;

public class GameReady : MonoBehaviour {
    public GameObject m_GameStartBtn;
    public GameObject m_GameExitBtn;

	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_GameStartBtn).onClick = OnGameStartBtnClick;
        UIEventListener.Get(m_GameExitBtn).onClick = OnGameExitBtnClick;
	}

    private void OnGameStartBtnClick(GameObject btn) {
        GameStatusMessage msg = new GameStatusMessage();
        msg.Status = GameStatus.GamePlaying;
        Message.Send<GameStatusMessage>(msg);
        Destroy(gameObject);
    }

    private void OnGameExitBtnClick(GameObject btn) {
        GameStatusMessage msg = new GameStatusMessage();
        msg.Status = GameStatus.GameExit;
        Message.Send<GameStatusMessage>(msg);
        Destroy(gameObject);
    }
}