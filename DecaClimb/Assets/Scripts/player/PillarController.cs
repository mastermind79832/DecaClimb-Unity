using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecaClimb
{
    public class PillarController : MonoBehaviour
    {
        private Vector2 lastTapPos;
        private Vector3 startRotation;
        [SerializeField] private float m_Speed;
        // Start is called before the first frame update
        void Start()
        {
            startRotation = transform.localEulerAngles;
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

                if (lastTapPos == Vector2.zero)
                {
                    lastTapPos = curTapPos;
                }

                float delta = lastTapPos.x - curTapPos.x;
                lastTapPos = curTapPos;

                transform.Rotate(delta * m_Speed * Vector3.up / 100);

            }

            if (Input.GetMouseButtonUp(0))
            {
                lastTapPos = Vector2.zero;
            }
        }

    }
}