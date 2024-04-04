using UnityEngine;


namespace Revity.DecaClimb
{
    public class PillarSpwan : MonoBehaviour
    {

        public GameObject pillar;
        public GameObject coinSpawnner;

        GameObject pillars;

        public static int lastpillar;

        private int minPillar;
        private int maxPillar;

        // Start is called before the first frame update
        void Start()
        {
            int level = levelsHandle.GetCurrentLevel();
            if (level == 0)
            {
                minPillar = 4;
                maxPillar = 5;
            }
            else if (level > 10)
            {
                minPillar = level;
                maxPillar = level + 3;
            }
            else
            {
                minPillar = 7;
                maxPillar = 10;
            }

            SpwanPillars();

        }

        private void SpwanPillars()
        {
            int pillarAmount = Random.Range(minPillar, maxPillar);

            for (int i = 0; i < pillarAmount; i++)
            {
                pillars = Instantiate(pillar);
                pillars.transform.position = new Vector3(transform.position.x, i * 4, transform.position.z);
                pillars.transform.parent = transform;
                SpwanCoinSpwaner();

                if (i == 0)
                {
                    pillars.GetComponent<GroundSpwanner>().first = true;
                }


            }

            pillars = Instantiate(pillar);
            lastpillar = pillarAmount * 4;
            ProgressBarScript.StartProgress();
            pillars.transform.position = new Vector3(transform.position.x, lastpillar, transform.position.z);
            pillars.transform.parent = transform;

            pillars.GetComponent<GroundSpwanner>().last = true;
        }

        private void SpwanCoinSpwaner()
        {
            int isCoin = Random.Range(0, 2);

            if (isCoin == 1)
            {
                Instantiate(coinSpawnner, pillars.transform.position, Quaternion.identity, transform);

            }
        }

    }
}