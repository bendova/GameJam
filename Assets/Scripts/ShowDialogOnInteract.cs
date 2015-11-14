using System;
using UnityEngine;

namespace GameJam
{
    public class ShowDialogOnInteract : MonoBehaviour
    {
        public Dialog m_Dialog;

        public bool m_HasShownDialog = false;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if((m_HasShownDialog == false) && (other.gameObject == GameController.Player))
            {
                NarativeManager.Instance.TriggerDialog(m_Dialog);
                m_HasShownDialog = true;
            }
        }
    }
}


