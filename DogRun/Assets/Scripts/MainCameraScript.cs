using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {
    public GameObject m_Target;
    public float m_OffsetY;
    public float m_OffsetZ;
	void LateUpdate () {
        if (m_Target == null)
            return;
        transform.position = m_Target.transform.position + new Vector3(0, m_OffsetY, m_OffsetZ);
    }
}
