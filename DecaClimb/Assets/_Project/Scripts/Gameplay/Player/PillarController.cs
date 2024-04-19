using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb.Game
{
    public class PillarController : MonoBehaviour
    {
        private Vector2 m_LastTapPos;
        private bool m_NewTap;
        [SerializeField] private float m_Speed;
        // Start is called before the first frame update
        void Start()
        {
            m_NewTap = true;
        }

        // Update is called once per frame
        void Update()
        {
            PillarMovement();
        }

        private void PillarMovement()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 curTapPos = Input.mousePosition;

                if (m_NewTap)
                {
                    m_LastTapPos = curTapPos;
                }

                float delta = m_LastTapPos.x - curTapPos.x;
                m_LastTapPos = curTapPos;

                transform.Rotate(delta * m_Speed * Vector3.up / 100);
                m_NewTap = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                m_NewTap = true;
            }
        }

    }
}