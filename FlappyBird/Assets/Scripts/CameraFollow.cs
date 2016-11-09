using UnityEngine;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    float cameraZ;
    void Start()
    {
        cameraZ = transform.position.z;
    }
    void Update()
    {
        transform.position = new Vector3(Player.position.x, 0, cameraZ);
    }
}
