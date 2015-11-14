using UnityEngine;
using System.Collections;

namespace GameJam
{
    public class ConditionNot : MonoBehaviour, ActionCondition
    {
        public MonoBehaviour m_Condition;

        public bool IsTrue()
        {
            if ((m_Condition is ActionCondition) == false)
            {
                Debug.LogError("ConditionNot::IsTrue() The condition considered is not an ActionCondition: " + m_Condition);
            }

            bool isTrue = false;
            if (m_Condition && (m_Condition is ActionCondition))
            {
                isTrue = !(m_Condition as ActionCondition).IsTrue();
            }
            return isTrue;
        }
    }
}

