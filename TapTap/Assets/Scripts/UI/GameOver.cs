using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public GameObject m_RestartBtn;
    public GameObject m_ExitBtn;

	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_RestartBtn).onClick = OnRestartBtnClick;
        UIEventListener.Get(m_ExitBtn).onClick = OnExitBtnClick;
	}
	
    private void OnRestartBtnClick(GameObject btn) {
        GameStatusMessage msg = new GameStatusMessage();
        msg.Status = GameStatus.GamePlaying;
        Message.Send(msg);
        Destroy(gameObject);
    }

    private void OnExitBtnClick(GameObject btn) {
        GameStatusMessage msg = new GameStatusMessage();
        msg.Status = GameStatus.GameReady;
        Message.Send(msg);
        Destroy(gameObject);
    }
}
