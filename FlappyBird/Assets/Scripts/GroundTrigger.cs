using UnityEngine;
using System.Collections;

public class GroundTrigger : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ground")
            FloorManagerScript.UpdateFloor();
    }
}
