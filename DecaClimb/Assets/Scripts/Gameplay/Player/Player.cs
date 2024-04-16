using UnityEngine;

namespace Revity.DecaClimb.Game
{
    public class Player : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private float m_GroundError;
        [SerializeField] private float m_JumpPower = 5.2f;
        private float m_JumpVelocity;

        [Header("Multiplier")]
        [SerializeField] private TextMesh m_MultiplierPopup;

        private int m_CurrentGroundLevel = 4;
        private bool b_isDead = false;

        [Header("Referneces")]
        [SerializeField] private Rigidbody m_RigidBody;
        [SerializeField] private Collider m_Collider;
        [SerializeField] private TrailRenderer m_TrailRenderer;

        private GameManager m_GameManager;
        private ScoreManager m_ScoreManager;
        //[SerializeField] private GameObject m_ProgressBar;

        private Vector3 m_staringPos = new Vector3(0, 3.3f, -5);

        // Start is called before the first frame update
        void Start()
        {
           // m_staringPos = transform.position;
        }

        public void InjectDependecies(GameManager gameManager, ScoreManager scoreManager)
        {
            m_GameManager = gameManager;
            m_ScoreManager = scoreManager;

            m_ScoreManager.OnMultiplierChanged += SetMultiplier;
        }

        private void SetMultiplier(int multiplier)
        {
			if (multiplier >= 2)
			{
				m_MultiplierPopup.GetComponent<TextMesh>().text = "x" + multiplier.ToString();
				m_MultiplierPopup.gameObject.SetActive(true);
			}
            else
            {
				m_MultiplierPopup.gameObject.SetActive(false);
			}
		}

        // Update is called once per frame
        void Update()
        {
            JumpControl();
            OutofBound();
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
			if (b_isDead) return;
			if (!other.gameObject.TryGetComponent(out Ground ground)) return;

			if (!IsPlayerAboveGround(ground)) return;

			else if (ground.GroundType == GroundType.Danger && GroundError(ground))
			{
				b_isDead = true;
				m_GameManager.GameOver();

			}
			else if (ground.GroundType == GroundType.Goal && GroundError(ground))
			{
				m_GameManager.GameFinish();
			}
			else if (ground.GroundType == GroundType.Normal)
			{
				m_RigidBody.velocity = Vector3.up * m_JumpVelocity;
				CheckFloorPassed(ground);
			}

		}
        private void CheckFloorPassed(Ground ground)
        {
            if (m_CurrentGroundLevel < ground.GetLevel())
            {
                m_ScoreManager.IncreaseScore();
                m_CurrentGroundLevel = ground.GetLevel();
                //m_ProgressBar.GetComponent<ProgressBarScript>().progressionBarUpdate(m_FloorPos);
            }
        }

		private bool GroundError(Ground ground) =>
			transform.position.y - ground.transform.position.y > m_GroundError;

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
            m_Collider.enabled = false;
			m_TrailRenderer.enabled = false;
            transform.position = m_staringPos;
			Invoke(nameof(StartTrail), 1f);
			m_Collider.enabled = true;

            m_CurrentGroundLevel = 0;
            b_isDead = false;
		}

        private void StartTrail()
        {
			m_TrailRenderer.enabled = true;

        }
	}
}