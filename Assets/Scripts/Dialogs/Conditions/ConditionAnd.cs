using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class ConditionAnd : MonoBehaviour, ActionCondition
    {
        public DialogTrigger[] m_DialogLabels;

        public bool IsTrue()
        {
            bool isTrue = true;
            for (int i = 0; i < m_DialogLabels.Length; ++i)
            {
                if (NarativeManager.Instance.DoesPlayerHaveDialogTriggered(m_DialogLabels[i]) == false)
                {
                    isTrue = false;
                    break;
                }
            }

            return isTrue;
        }
    }
}


