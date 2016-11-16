using UnityEngine;
using System.Collections.Generic;

public class FloorManagerScript : MonoBehaviour {

    public GameObject groundPrefab;
    public GameObject pipePrefab;
    public Transform pipeGenPoint;
    public static List<GameObject> groundList = new List<GameObject>();
    public static List<GameObject> pipeList = new List<GameObject>();

    private float m_SumTime = 0;
    private float m_GenInterval = 2.0f;

	void Awake () {
        float x = 0;
        for (int i=0; i<2; ++i)
        {
            GameObject ground = Instantiate(groundPrefab);
            ground.transform.SetParent(transform);
            ground.transform.localPosition = new Vector3(x, 0, 0);
            groundList.Add(ground);
            x += 3.34f;
        }
	}

	void Update () {
        m_SumTime += Time.deltaTime;
        if (m_SumTime > m_GenInterval)
        {
            m_SumTime -= m_GenInterval;
            CreatePipe();
        }
	}

    public static void UpdateFloor()
    {
        if (groundList == null || groundList.Count == 0)
            return;
        foreach (GameObject ground in groundList)
            if (ground != null)
                ground.transform.localPosition += new Vector3(3.34f, 0);
    }

    public void CreatePipe()
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            GameObject pipe = Instantiate(pipePrefab, transform, false) as GameObject;
            float y = Random.Range(-0.5f, 1f);
            float offx = Random.Range(-0.3f, 0.3f);
            pipe.transform.position = new Vector3(pipeGenPoint.position.x+offx, y, 0);
            pipeList.Add(pipe);
        }
    }

    public static void RemovePipe(GameObject pipe)
    {
        pipeList.Remove(pipe);
        Destroy(pipe);
    }
}
