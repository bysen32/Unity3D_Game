using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class JellyFishController : Controller<JellyFishModel>
{
    [SerializeField]
    private UILabel m_MarkLabel;
    private float RedirectGap = 3f;
    [SerializeField]
    [Range(0, 0.5f)]
    private float MinMoveDistance = 0.25f;
    [SerializeField]
    [Range(0.5f, 1.25f)]
    private float MaxMoveDistance = 0.8f;


    protected override void OnInitialize()
    {
        m_MarkLabel.text = model.MarkID.ToString();
        UIEventListener.Get(gameObject).onClick += OnJellyFishClick;
    }

    protected override void OnModelChanged()
    {
        base.OnModelChanged();
        m_MarkLabel.text = model.MarkID.ToString();
    }

    private void Update()
    {
        if (model.LastRedirectTime < 0 || Time.time - model.LastRedirectTime > RedirectGap)
        {
            model.LastRedirectTime = Time.time;
            float distance = UnityEngine.Random.Range(MinMoveDistance, MaxMoveDistance);
            for (int i=0; i<10; ++i)
            {
                Vector3 direction = new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f), 0).normalized * distance;
                bool enable = true;
                for (int k=0; k<2; ++k) {
                    direction *= -1;
                    RaycastHit[] hitInfos = Physics.RaycastAll(transform.position, direction, distance);
                    foreach (RaycastHit hitInfo in hitInfos)
                        if (hitInfo.collider.tag == "wall")
                            enable = false;
                    if (enable) break;
                }

                if (enable) {
                    model.TargetPos = transform.position + direction;
                    break;
                }
            }
        }
        transform.position = Vector3.Lerp(transform.position, model.TargetPos, 0.01f);
        model.Position = transform.position;
    }

    private void OnJellyFishClick(GameObject obj) {
        JellyFishMessage msg = new JellyFishMessage();
        msg.MarkID = model.MarkID;
        Message.Send("click", msg);
    }
}