using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Base
{
    public class ViewBase : MonoBehaviour
    {
        public void OnDestroy() {
            Debug.Log("OnDestroy");
        }
    }
}
