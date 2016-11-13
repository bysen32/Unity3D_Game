using UnityEngine;
using System.Collections.Generic;

public class pipeManager : MonoBehaviour {

    public GameObject pipePrefab;
    public Transform pipeGenPoint;
    public float pipeTimeGap = 2;
    private List<GameObject> pipeList = new List<GameObject>();
    private float m_SumTime = 0;

	void Update () {
        m_SumTime += Time.deltaTime;
        if (m_SumTime > pipeTimeGap)
        {
            m_SumTime -= pipeTimeGap;
            GameObject pipe = Instantiate(pipePrefab, pipeGenPoint, false) as GameObject;
            pipe.transform.localPosition = pipeGenPoint.position;
            pipeList.Add(pipe);
        }
	}
}
