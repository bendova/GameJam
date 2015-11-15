using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class ChangeLevelOnInteract : MonoBehaviour, ActionTrigger
    {
        public Levels m_LevelToLoad = Levels.Level_None;
        public bool m_ChangeLevelOnInteract = true;

        public static Dictionary<Levels, string> s_LevelsMap = new Dictionary<Levels, string>()
        {
            {Levels.Level_None,         "" },
            {Levels.Level_WhiteRoom,    "Level_01" },
            {Levels.Level_ThroneRoom,   "Level_02" }, //FIXME
            {Levels.Level_Village,      "Level_03" },
            {Levels.Level_Lake,         "Level_04" },
            {Levels.Level_DragonLair,   "Level_05" },
        };

        void OnTriggerStay2D(Collider2D other)
        {
            if (m_ChangeLevelOnInteract == false)
            {
                return;
            }

            if (other.gameObject == GameController.Player)
            {
                if(GameController.PlayerCtrl.IsInteracting())
                {
                    ChangeLevel();
                }
            }
        }

        public void Trigger()
        {
            ChangeLevel();
        }

        private void ChangeLevel()
        {
            GameController.Instance.ChangeLevel(s_LevelsMap[m_LevelToLoad]);
        }
    }
}
