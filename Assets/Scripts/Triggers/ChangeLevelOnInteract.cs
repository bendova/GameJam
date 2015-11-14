using UnityEngine;

namespace GameJam
{
    public class ChangeLevelOnInteract : MonoBehaviour, ActionTrigger
    {
        public string m_LevelToLoad = "";
        public bool m_ChangeLevelOnInteract = true;

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
            GameController.Instance.ChangeLevel(m_LevelToLoad);
        }
    }
}
