using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Base
{
    class UIManagement
    {
        private static UIManagement instance;

        private List<GameObject> m_DlgCaches;

        #region #DelegateDefine
        public delegate void OnCloseDelegate(GameObject obj);
        public OnCloseDelegate OnClose;
        #endregion

        public static UIManagement GetInstance()
        {
            if (instance == null) {
                instance = new UIManagement();
            }
            return instance;
        }
    }
}
