using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace GameJam
{
    public class ScreenFader : MonoBehaviour
    {
        public Image m_ScreenFadeImage;
        public float m_FadeSpeed = 10f;

        private bool m_IsScreenFadingToClear = false;
        private bool m_IsScreenFadingToBlack = false;

        // Use this for initialization
        void Start()
        {
            m_IsScreenFadingToClear = true;
            m_ScreenFadeImage.enabled = true;
        }

        void Update()
        {
            if (m_IsScreenFadingToClear)
            {
                FadeScreenToClear();
            }
            else if (m_IsScreenFadingToBlack)
            {
                FadeScreenToBlack();
            }
        }

        public void StartScreenFadeToBlack()
        {
            m_IsScreenFadingToBlack = true;
            m_ScreenFadeImage.enabled = true;
        }

        private void FadeScreenToClear()
        {
            m_ScreenFadeImage.color = Color.Lerp(m_ScreenFadeImage.color, Color.clear, m_FadeSpeed * Time.deltaTime);
            if (m_ScreenFadeImage.color.a <= 0.05f)
            {
                m_ScreenFadeImage.color = Color.clear;
                m_ScreenFadeImage.enabled = false;

                m_IsScreenFadingToClear = false;
            }
        }

        private void FadeScreenToBlack()
        {
            m_ScreenFadeImage.color = Color.Lerp(m_ScreenFadeImage.color, Color.black, m_FadeSpeed * Time.deltaTime);
            if (m_ScreenFadeImage.color.a >= 0.95f)
            {
                m_ScreenFadeImage.color = Color.clear;
                m_IsScreenFadingToBlack = false;
                GameController.Instance.OnScreenFadeDone();
            }
        }
    }
}
