using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {
    public float m_Velocity = 10;
    public GameObject m_MoveObj;

    void FixedUpdate()
    {
        if (m_MoveObj == null)
            return;

        float tm = Time.deltaTime;
        Vector3 dir = new Vector3(0, 0, 1);
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.point.z > m_MoveObj.transform.position.z)
                {
                    m_MoveObj.transform.LookAt(new Vector3(hit.point.x, m_MoveObj.transform.position.y, hit.point.z));
                }
                Vector3 pos = transform.localPosition;
                if (Mathf.Abs(hit.point.x - transform.position.x) > 2.0)
                    dir += new Vector3(hit.point.x - transform.position.x, 0, 0).normalized;
            }
        }
        else
        {
            m_MoveObj.transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        transform.position += dir.normalized * m_Velocity * tm;
    }
}
