using UnityEngine;
using System.Collections.Generic;
using System;

public class FloorManagerScript : MonoBehaviour {

    public GameObject groundPrefab;
    public static List<GameObject> groundList = new List<GameObject>();
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
	
	}

    public static void UpdateFloor()
    {
        if (groundList == null || groundList.Count == 0)
            return;
        foreach (GameObject ground in groundList)
            if (ground != null)
                ground.transform.localPosition += new Vector3(3.34f, 0);
    }
}
