using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class ConditionOr : MonoBehaviour, ActionCondition
    {
        public DialogTrigger[] m_DialogLabels;

        public bool IsTrue()
        {
            bool isTrue = false;
            for (int i = 0; i < m_DialogLabels.Length; ++i)
            {
                if (NarativeManager.Instance.DoesPlayerHaveDialogTriggered(m_DialogLabels[i]))
                {
                    isTrue = true;
                    break;
                }
            }

            return isTrue;
        }
    }
}


