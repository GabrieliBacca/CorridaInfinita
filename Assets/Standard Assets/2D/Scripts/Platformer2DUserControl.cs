using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private Canvas GameOver;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            GameObject tempGO = GameObject.Find("GameOver");
            if (tempGO != null){
                GameOver = tempGO.GetComponent<Canvas>();
            }
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetMouseButtonDown(0);
            }
            if(Time.timeScale < 0.1)
            {
                GameOver.gameObject.SetActive(true);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            //float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(1, false, m_Jump);
            m_Jump = false;
        }
    }
}
