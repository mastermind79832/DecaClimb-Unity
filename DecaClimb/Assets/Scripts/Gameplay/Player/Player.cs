using UnityEngine;

namespace Revity.DecaClimb.Game
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float m_GoalError;
        private float m_JumpVelocity;
        [SerializeField] private float m_JumpPower = 5.2f;

        [SerializeField] private GameObject m_MultiplierPopup;

        [SerializeField] private float m_MaxMultiplierTime = 2;

        private int m_Multiplier;

        private float m_MultiplierTime;

        [SerializeField] private Rigidbody m_RigidBody;
        private float m_FloorPos = 4;
        private bool b_isDead = false;

        [SerializeField] private GameManager m_GameManager;

        [SerializeField] private GameObject m_ProgressBar;

        private Vector3 m_staringPos = new Vector3(0, 3.3f, -5);

        // Start is called before the first frame update
        void Start()
        {
           m_MultiplierTime = m_MaxMultiplierTime;
           // m_staringPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {

            JumpControl();

            // FloorPassed();

            OutofBound();

            m_MultiplierTime += Time.deltaTime;

            if (m_MultiplierTime >= m_MaxMultiplierTime)
            {
                m_Multiplier = 0;
                m_MultiplierPopup.SetActive(false);
            }
        }

        private void JumpControl()
        {
            if (Input.GetMouseButton(0))
                m_JumpVelocity = m_JumpPower * 2;
            else if (b_isDead)
                m_JumpVelocity = 0;
            else
                m_JumpVelocity = m_JumpPower;
        }

        private void FloorPassed()
        {
            if (transform.position.y > m_FloorPos)
            {
                SetMultiplier();
                GameSceneService.Instance.ScoreManager.IncreaseScore();
                m_FloorPos = m_FloorPos + 4;
                m_ProgressBar.GetComponent<ProgressBarScript>().progressionBarUpdate(m_FloorPos);
                // Debug.Log(ScoreScript.GetScore());
            }
        }

        private void SetMultiplier()
        {

            m_Multiplier += 1;
            m_MultiplierTime = 0;

            if (m_Multiplier >= 2)
            {
                m_MultiplierPopup.GetComponent<TextMesh>().text = "x" + m_Multiplier.ToString();
                m_MultiplierPopup.SetActive(true);
            }
        }

        private void OutofBound()
        {
            if (transform.position.y < -2)
            {
                gameObject.SetActive(false);
                m_GameManager.GameOver();
            }
        }

        private void OnCollisionEnter(Collision other)
		{
			if (b_isDead) { return; }
			if (!other.gameObject.TryGetComponent(out Ground ground)) return;

			if (!IsPlayerAboveGround(ground)) return;

			if (ground.GroundType == GroundType.Normal)
			{
				m_RigidBody.velocity = Vector3.up * m_JumpVelocity;
				FloorPassed();

			}
			else if (ground.GroundType == GroundType.Danger)
			{
				b_isDead = true;
				//Debug.Log("DEad");
				m_GameManager.GameOver();

			}
			else if (ground.GroundType == GroundType.Goal && GroundError(ground))
			{
				m_GameManager.GameFinish();
			}

		}

		private bool GroundError(Ground ground) =>
			transform.position.y - ground.transform.position.y > m_GoalError;

		private bool IsPlayerAboveGround(Ground ground) => 
            ground.transform.position.y < transform.position.y;

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
            gameObject.SetActive(true);
            GetComponent<Collider>().enabled = false;
			transform.GetChild(0).GetComponent<TrailRenderer>().enabled = false;
            transform.position = m_staringPos;
			Invoke(nameof(StartTrail), 1f);
            GetComponent<Collider>().enabled = true;

            m_FloorPos = 4;
            b_isDead = false;
		}

        private void StartTrail()
        {
			transform.GetChild(0).GetComponent<TrailRenderer>().enabled = true;

        }
	}
}