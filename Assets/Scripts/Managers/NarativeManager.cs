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

        private static List<DialogTrigger> m_TriggeredDialogs = new List<DialogTrigger>() { DialogTrigger.None, DialogTrigger.None, DialogTrigger.None };
        private static int m_nextTriggerDialogIndex = 0;

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

            int i = 0;
            int choiceButtonIndex = 0;
            for (; i < m_Dialog.m_Choices.Length; ++i)
            {
                Choice choice = m_Dialog.m_Choices[i];
                if (choice.m_Condition && (choice.m_Condition is ActionCondition))
                {
                    bool isValid = (choice.m_Condition as ActionCondition).IsTrue();
                    if (isValid == false)
                    {
                        continue;
                    }
                }

                bool isPressed = CrossPlatformInputManager.GetButtonDown(m_ChoiceButtons[choiceButtonIndex]);
                if (isPressed)
                {
                    m_InputWaitTimer = 0f;

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

                ++choiceButtonIndex;
            }
        }

        public void TriggerDialog(Dialog dialog)
        {
            m_Dialog = dialog;
            if ((dialog.m_DialogTrigger != DialogTrigger.None) && 
                (m_TriggeredDialogs.Contains(dialog.m_DialogTrigger) == false))
            {
                m_TriggeredDialogs[m_nextTriggerDialogIndex] = dialog.m_DialogTrigger;
                ++m_nextTriggerDialogIndex;
            }
            UiManager.Instance.ShowDialog(dialog);
            if ((m_Dialog.m_Choices.Length > 0) && dialog.m_BlockPlayerInput)
            {
                GameController.PlayerCtrl.BlockInput();
            }
            else
            {
                GameController.PlayerCtrl.UnblockInput();
            }
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
            return m_TriggeredDialogs.Contains(trigger);
        }

        public bool DoesPlayerHaveDialogTriggered(DialogTrigger trigger, int index)
        {
            return (m_TriggeredDialogs[index] == trigger);
        }
    }
}


