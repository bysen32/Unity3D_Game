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
        OpenUI("UI/GameScene");
        Destroy(gameObject);
    }
    private void OnGameExitBtnClick(GameObject btn) {
        Destroy(gameObject);
    }

    private void OpenUI(string path) {
        GameObject ui = Instantiate(Resources.Load(path)) as GameObject;
        ui.transform.parent = GameObject.Find("main").transform;
        ui.transform.localPosition = Vector3.zero;
        ui.transform.localScale = Vector3.one;
    }
}