using UnityEngine;
using System.Collections.Generic;

public class GameObjManager : MonoBehaviour {
    public enum POP_STATE {
        NONE,
        NEEDMORE,
        LEN,
    }

    public static GameObjManager instance;

    #region Relative of PopObjects
    public Object m_PopPrefab;
    public List<GameObject> m_PopObjects = new List<GameObject>();

    public float m_GenPopGapTime;
    private float m_LastGenPopTime;
    public int MAX_SCORE = 11;
    #endregion

    #region Global Static Setting
    public List<Transform> m_GenPoints = new List<Transform>();
    public List<float> m_Lv2Speed = new List<float>(10);
    public List<float> m_Lv2PopCnt = new List<float>(10);
    #endregion

    #region Callback
    #endregion

    // Use this for initialization
    void Start () {
        m_LastGenPopTime = Time.time;
        if (instance == null) {
            instance = this;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GenPopEnable()) {
            GenPop();
        }
        /*
        if (Input.GetMouseButtonDown(0)) {
            Vector2 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo)) {
                GameObject gameobj = hitInfo.collider.gameObject;
                if (gameobj.tag == "PopObj") {
                    RemovePop(gameobj);
                }
            }
        }
        */
	}

    #region Functions of GenPopObj
    private bool GenPopEnable() {
        if (Time.time - m_LastGenPopTime < m_GenPopGapTime) {
            return false;
        }
        if (GameScene.GetInstance().m_GameState != GameScene.GAME_STATE.PLAYING){
            return false;
        }

        int level = GameScene.GetInstance().Level;
        if (m_PopObjects.Count >= m_Lv2PopCnt[level]) {
            return false;
        }
        return true;
    }

    private void GenPop() {
        GameObject obj = Instantiate(m_PopPrefab) as GameObject;
        obj.transform.parent = GameObject.Find("main").transform;
        obj.transform.position = GetRandomGenPoint();
        obj.transform.localScale = Vector3.one;
        obj.SetActive(true);
        m_PopObjects.Add(obj);
        m_LastGenPopTime = Time.time;
        UIEventListener.Get(obj).onPress = OnPopObjClick;

        int max = MAX_SCORE;
        foreach(GameObject o in m_PopObjects) {
            max = Mathf.Max(max, o.GetComponent<PopScript>().Score);
        }
        MAX_SCORE = max + 1;
        obj.GetComponent<PopScript>().Score = MAX_SCORE;
    }

    private Vector3 GetRandomGenPoint() {
        int idx = Random.Range(0, m_GenPoints.Count);
        return m_GenPoints[idx].position;
    }
    #endregion

    public static GameObjManager GetInstance() {
        return instance;
    }

    public void OnPopObjClick(GameObject obj, bool state) {
        foreach( GameObject o in m_PopObjects) {
            if (o.GetComponent<PopScript>().Score < obj.GetComponent<PopScript>().Score)
            {
                GameScene.GetInstance().GameOver();
                return;
            }
        }
        RemovePop(obj);
        GameScene.GetInstance().Score += 1;
    }

    private void RemovePop(GameObject obj) {
        m_PopObjects.Remove(obj);
        Destroy(obj);
    }
}
