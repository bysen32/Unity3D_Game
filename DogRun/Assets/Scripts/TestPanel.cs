using UnityEngine;
using System.Collections;

public class TestPanel : MonoBehaviour {
    public GameObject m_Btn1;
    public GameObject m_Btn2;
    public GameObject m_Btn3;
	// Use this for initialization
	void Start () {
        UIEventListener.Get(m_Btn1).onClick = OnBtn1Click;
        UIEventListener.Get(m_Btn2).onClick = OnBtn2Click;
        UIEventListener.Get(m_Btn3).onClick = OnBtn3Click;
	}
	
    void OnBtn1Click(GameObject btn) {
        Debug.Log("OnBtn1Click");
    }
    void OnBtn2Click(GameObject btn) {
        Debug.Log("OnBtn2Click");
    }
    void OnBtn3Click(GameObject btn) {
        Debug.Log("OnBtn3Click");
    }
}
