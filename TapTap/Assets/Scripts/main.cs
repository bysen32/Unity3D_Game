using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        OpenUI("UI/GameReady");
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OpenUI(string path) {
        GameObject ui = Instantiate(Resources.Load(path)) as GameObject;
        ui.transform.parent = GameObject.Find("main").transform;
        ui.transform.localPosition = Vector3.zero;
        ui.transform.localScale = Vector3.one;
    }
}
