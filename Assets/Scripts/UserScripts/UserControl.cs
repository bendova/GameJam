using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace GameJam
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class UserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Interact;
        private bool m_isInputBlocked = false;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
            m_Interact = CrossPlatformInputManager.GetButton("Interact");
        }
        
        private void FixedUpdate()
        {
            if (m_isInputBlocked == false)
            {
                // Read the inputs.
                bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                m_Character.Move(h, crouch, m_Jump);
                m_Jump = false;
            }
        }

        public bool IsInteracting()
        {
            return m_Interact;
        }

        public void BlockInput()
        {
            m_isInputBlocked = true;
            m_Character.Move(0, false, false);
        }

        public void UnblockInput()
        {
            m_isInputBlocked = false;
        }
    }
}
