using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class JellyFishController : Controller<JellyFishModel>
{
    [SerializeField]
    private UILabel m_MarkLabel;

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

    private void Update() {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 1));
    }

    private void OnJellyFishClick(GameObject obj) {
        JellyFishMessage msg = new JellyFishMessage();
        msg.MarkID = model.MarkID;
        Message.Send("click", msg);
    }
}