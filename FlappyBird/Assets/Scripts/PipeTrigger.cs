using UnityEngine;
using System.Collections;

public class PipeTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(string.Format("tag={0}", col.gameObject.tag));
        if (col.gameObject.tag == "pipe" || col.gameObject.tag == "pipeblank" )
        {
            FloorManagerScript.RemovePipe(col.transform.parent.gameObject);
        }
    }
}
