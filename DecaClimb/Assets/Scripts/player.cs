using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DecaClimb
{
    public class player : MonoBehaviour
    {

        private float jumpvelocity;
        public float jp = 7f;

        public GameObject multiplierDisp;

        public float maxMultTime;

        private int multiplier;

        private float multiplierTime;

        public Rigidbody rb;
        float pos = 4;
        private bool isDead = false;

        public GameManager gm;

        public GameObject progressPos;

        // Start is called before the first frame update
        void Start()
        {

            multiplierTime = maxMultTime;

        }

        // Update is called once per frame
        void Update()
        {

            JumpControl();

            // FloorPassed();

            OutofBound();

            multiplierTime += Time.deltaTime;

            if (multiplierTime >= maxMultTime)
            {
                multiplier = 0;
                multiplierDisp.SetActive(false);
            }
        }

        private void JumpControl()
        {
            if (Input.GetMouseButton(0))
                jumpvelocity = jp * 2;
            else if (isDead)
                jumpvelocity = 0;
            else
                jumpvelocity = jp;
        }

        private void FloorPassed()
        {
            if (transform.position.y > pos)
            {
                SetMultiplier();
                ScoreScript.IncreaseScore(multiplier);
                pos = pos + 4;
                progressPos.GetComponent<ProgressBarScript>().progressionBarUpdate(pos);
                // Debug.Log(ScoreScript.GetScore());
            }
        }

        private void SetMultiplier()
        {

            multiplier += 1;
            multiplierTime = 0;

            if (multiplier >= 2)
            {
                multiplierDisp.GetComponent<TextMesh>().text = "x" + multiplier.ToString();
                multiplierDisp.SetActive(true);
            }

        }

        private void OutofBound()
        {
            if (transform.position.y < -2)
            {
                Destroy(gameObject);
                gm.GameOver();
            }
        }

        private void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "Ground")
            {
                rb.velocity = Vector3.up * jumpvelocity;
                FloorPassed();

            }
            else if (other.gameObject.tag == "Danger")
            {
                isDead = true;
                //Debug.Log("DEad");
                gm.GameOver();

            }
            else if (other.gameObject.tag == "Finish" && PillarSpwan.lastpillar < transform.position.y)
            {
                gm.GameFinish();
            }

        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Coin")
            {
                // coin amount update

                CoinsManagerScript.IncreaseCoin(1);

                // destroy Coin

                Destroy(other.gameObject);
                //Debug.Log("coin");

            }
        }

    }
}