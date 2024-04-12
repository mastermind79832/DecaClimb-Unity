using UnityEngine;

namespace Revity.DecaClimb.Game
{
    public class Player : MonoBehaviour
    {
        private float jumpvelocity;
        [SerializeField] private float jp = 5.2f;

        [SerializeField] private GameObject multiplierDisp;

        [SerializeField] private float maxMultTime = 2;

        private int multiplier;

        private float multiplierTime;

        [SerializeField] private Rigidbody rb;
        float pos = 4;
        private bool isDead = false;

        [SerializeField] private GameManager gm;

        [SerializeField] private GameObject progressPos;

        private Vector3 m_staringPos = new Vector3(0, 3.3f, -5);

        // Start is called before the first frame update
        void Start()
        {
           multiplierTime = maxMultTime;
           // m_staringPos = transform.position;
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
                GameSceneService.Instance.ScoreManager.IncreaseScore();
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
            if (!other.gameObject.TryGetComponent(out Ground ground)) return;

            if (!IsPlayerAboveGround(ground)) return;

            if (ground.GroundType == GroundType.Normal)
            {
                rb.velocity = Vector3.up * jumpvelocity;
                FloorPassed();

            }
            else if (ground.GroundType == GroundType.Danger)
            {
                isDead = true;
                //Debug.Log("DEad");
                gm.GameOver();

            }
            else if (ground.GroundType == GroundType.Goal)
            {
                gm.GameFinish();
            }

        }
        private bool IsPlayerAboveGround(Ground ground) => ground.transform.position.y < transform.position.y;

		private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.TryGetComponent(out Coin coin))
            {
                GameSceneService.Instance.CoinManager.IncreaseCoin(coin.Valve);
                other.gameObject.SetActive(false);
            }
        }

		public void ResetPosition()
		{
            GetComponent<Collider>().enabled = false;
			transform.GetChild(0).GetComponent<TrailRenderer>().enabled = false;
            transform.position = m_staringPos;
			Invoke(nameof(StartTrail), 1f);
            GetComponent<Collider>().enabled = true;

            pos = 4;
            isDead = false;
		}

        private void StartTrail()
        {
			transform.GetChild(0).GetComponent<TrailRenderer>().enabled = true;

        }
	}
}