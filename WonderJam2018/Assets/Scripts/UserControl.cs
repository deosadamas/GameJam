using System;
using UnityEngine;


[RequireComponent(typeof (Character2D))]
public class UserControl : MonoBehaviour
{
    private Character2D m_Character;
    private bool m_Jump;

    public string horizontalAxis;
    public string aButton;

    private void Awake()
    {
        m_Character = GetComponent<Character2D>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetButtonDown(aButton);
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = Input.GetAxis(horizontalAxis);
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}
