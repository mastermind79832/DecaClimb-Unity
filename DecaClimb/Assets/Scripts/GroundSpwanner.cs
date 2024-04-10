using UnityEngine;

namespace Revity.DecaClimb
{
    public class GroundSpwanner : MonoBehaviour
    {
        public GameObject ground;
        public Material redMat;
        public Material safeMat;

        public Material FinishMat;

        public bool first = false;
        public bool last = false;

        public int[] groundData;
        private Pillar pillar;

        // Start is called before the first frame update
        void Start()
		{
			//Initialize();
		}

		public void Initialize(bool first, bool last)
		{
            this.first = first;
            this.last = last;
			pillar = GetComponent<Pillar>();
			groundData = new int[10];

			GroundSpwan();
			GroundDestroy();
			SetDangerZone();

			pillar.SetGround(groundData);
		}

		private void GroundSpwan()
        {
            for (int i = 0; i < 10; i++)
            {
                groundData[i] = 0;
                //GameObject grounds = Instantiate(ground);
                //grounds.transform.position = transform.position;
                //grounds.transform.SetParent(transform);
                //grounds.transform.rotation = Quaternion.Euler(90, i * 36, 0);

                if (last)
                {
                    //grounds.GetComponent<MeshRenderer>().material = FinishMat;
                    //grounds.tag = "Finish";
                    groundData[i] = (int)GroundType.Goal;

                }
            }
        }

        private void GroundDestroy()
        {

            int amountToDestroy = Random.Range(2, 6);

            for (int i = 0; i < amountToDestroy; i++)
            {

                int index = Random.Range(0, 9);

                if (first)
                    index = Random.Range(2, 9);

                groundData[index] = 3;

               // Destroy(transform.GetChild(index).gameObject);
            }
        }

        private void SetDangerZone()
        {

            if (!last)
            {
                int dangerZone = Random.Range(1, 4);

                for (int i = 0; i < dangerZone; i++)
                {
                    int index = Random.Range(0, 9);

                    if (first)
                        index = Random.Range(2, 9);

                    if (groundData[index] == 3)
                    {
                        i--;
                        continue;
                    }
                    groundData[index] = (int)GroundType.Danger;
				//GameObject dangerGround = transform.GetChild(index).gameObject;
				//dangerGround.tag = "Danger";

				//MeshRenderer danger = dangerGround.GetComponent<MeshRenderer>();

				//if (danger.material == redMat)
				//    continue;
				//else
				//    danger.material = redMat;

			}
            }
        }

    }
}