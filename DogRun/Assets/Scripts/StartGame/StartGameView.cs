using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartGameView :  Assets.Scripts.Base.ViewBase {
    public GameObject m_StartGameBtn;
    public GameObject m_CloseBtn;
	void Start () {
        UIEventListener.Get(m_StartGameBtn).onClick = OnStartGameBtnClick;
        UIEventListener.Get(m_CloseBtn).onClick = OnCloseBtnClick;
	}

    void OnStartGameBtnClick(GameObject btn) {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    void OnCloseBtnClick(GameObject btn) {
        GameObject.Destroy(this.gameObject);
    }
}
