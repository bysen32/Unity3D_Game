using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
    public float m_Velocity = 10;
    public GameObject m_MoveObj;
    public float m_RotateSpeed = 8f;

    void FixedUpdate()
    {
        if (m_MoveObj == null)
            return;

        float tm = Time.deltaTime;
        Vector3 dir = new Vector3(0, 0, 1);
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                float deltaZ = Mathf.Abs(hit.point.z - m_MoveObj.transform.position.z);
                hit.point = new Vector3(hit.point.x, m_MoveObj.transform.position.y, m_MoveObj.transform.position.z + deltaZ);

                Quaternion rat = Quaternion.LookRotation(hit.point - m_MoveObj.transform.position);
                m_MoveObj.transform.rotation = Quaternion.Slerp(m_MoveObj.transform.rotation, rat, Mathf.Clamp01(m_RotateSpeed * tm));

                if (Mathf.Abs(hit.point.x - transform.position.x) > 2.0)
                    dir += new Vector3(hit.point.x - transform.position.x, 0, 0).normalized;
            }
        }
        else
        {
            Quaternion dst = new Quaternion(0, 0, 0, 1);
            m_MoveObj.transform.rotation = Quaternion.Slerp(m_MoveObj.transform.rotation, dst, Mathf.Clamp01(m_RotateSpeed * tm));
        }
#endif
        transform.position += dir.normalized * m_Velocity * tm;
    }
}
