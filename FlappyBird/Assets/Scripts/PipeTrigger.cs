using UnityEngine;
using System.Collections;

public class PipeTrigger : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pipe" || col.gameObject.tag == "pipeblank" )
            FloorManagerScript.RemovePipe(col.transform.parent.gameObject);
    }
}
