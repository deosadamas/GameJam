using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;



        bool isStun;


        public string Horizontal_Keyboard;
        public string Jump_Keyboard;

        public string Horizontal_Controller;
        public string Jump_Controller;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.

                m_Jump = CrossPlatformInputManager.GetButtonDown(Jump_Keyboard);
                if (m_Jump == false)
                {

                    m_Jump = CrossPlatformInputManager.GetButtonDown(Jump_Controller);
                }

            }

            transform.rotation = Quaternion.Euler(0, 0, 0);


        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h;
            float h1;



            h1 = CrossPlatformInputManager.GetAxis(Horizontal_Keyboard);
            h = CrossPlatformInputManager.GetAxis(Horizontal_Controller);






            // Pass all parameters to the character control script.

            if (h1 != 0)
            {
                m_Character.Move(h1, crouch, m_Jump);
            }
            else
            {
                m_Character.Move(h, crouch, m_Jump);
            }

            m_Jump = false;
        }
    }
}
