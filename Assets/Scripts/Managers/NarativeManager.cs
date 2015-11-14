using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

namespace GameJam
{
    public class NarativeManager : Singleton<NarativeManager>
    {
        public string[] m_ChoiceButtons;

        private Dictionary<DialogTrigger, bool> m_TriggeredDialogs = new Dictionary<DialogTrigger,bool>();

        private Dialog m_Dialog = null;

        private float m_InputWaitDuration = 0.5f;
        private float m_InputWaitTimer = 0f;

        void Start()
        {
            
        }

        void FixedUpdate()
        {
            if (m_Dialog == null)
            {
                return;
            }

            if (m_InputWaitTimer < m_InputWaitDuration)
            {
                m_InputWaitTimer += Time.deltaTime;
                return;
            }

            for (int i = 0; i < m_Dialog.m_Choices.Length; ++i)
            {
                bool isPressed = CrossPlatformInputManager.GetButtonDown(m_ChoiceButtons[i]);
                if (isPressed)
                {
                    m_InputWaitTimer = 0f;

                    Choice choice = m_Dialog.m_Choices[i];
                    if (choice.m_Trigger && (choice.m_Trigger is ActionTrigger))
                    {
                        (choice.m_Trigger as ActionTrigger).Trigger();
                    }

                    if (choice.m_NextDialog != null)
                    {
                        TriggerDialog(choice.m_NextDialog);
                    }
                    else
                    {
                        CloseDialog();
                    }
                }
            }
        }

        public void TriggerDialog(Dialog dialog)
        {
            m_Dialog = dialog;
            m_TriggeredDialogs[m_Dialog.m_DialogTrigger] = true;
            UiManager.Instance.ShowDialog(dialog);
            if (dialog.m_BlockPlayerInput)
            {
                GameController.PlayerCtrl.BlockInput();
            }
            else
            {
                GameController.PlayerCtrl.UnblockInput();
            }

            if (m_Dialog.m_Choices.Length > m_ChoiceButtons.Length)
            {
                Debug.LogError("NarativeManager::TriggerDialog() Trying to show a dialog with more buttons " +
                                "than there are actions available.");
            }

            // TODO if the dialog doesn't have any options then
            // automatically clear it after a while.
        }

        public void CloseDialog()
        {
            if (m_Dialog)
            {
                UiManager.Instance.ResetDialog();
                GameController.PlayerCtrl.UnblockInput();
            }
        }

        public bool DoesPlayerHaveDialogTriggered(DialogTrigger trigger)
        {
            return (m_TriggeredDialogs.ContainsKey(trigger) && m_TriggeredDialogs[trigger]);
        }
    }
}


