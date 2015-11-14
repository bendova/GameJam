using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace GameJam
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class UserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Interact;
        private bool m_IsInputBlocked = false;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            m_Interact = CrossPlatformInputManager.GetButton("Interact");
        }
        
        private void FixedUpdate()
        {
            if (m_IsInputBlocked == false)
            {
                // Read the inputs.
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h);
            }
        }

        public bool IsInteracting()
        {
            return m_Interact;
        }

        public void BlockInput()
        {
            m_IsInputBlocked = true;
            m_Character.Move(0);
        }

        public void UnblockInput()
        {
            m_IsInputBlocked = false;
        }
    }
}
