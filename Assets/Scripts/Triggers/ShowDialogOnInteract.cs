using System;
using UnityEngine;

namespace GameJam
{
    public class ShowDialogOnInteract : MonoBehaviour
    {
        public Dialog m_Dialog;
        public bool m_TriggerOnProximity = false;

        public bool m_HasShownDialog = false;
        
        void OnTriggerStay2D(Collider2D other)
        {
            if (m_HasShownDialog || (m_Dialog == null))
            {
                return;
            }

            if((other.gameObject == GameController.Player) &&
                (m_TriggerOnProximity ||
                GameController.PlayerCtrl.IsInteracting()))
            {
                NarativeManager.Instance.TriggerDialog(m_Dialog);
                m_HasShownDialog = true;
            }
        }
    }
}


