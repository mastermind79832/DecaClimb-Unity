using UnityEngine;


namespace Revity.DecaClimb.Game
{
    public class PillarSpwan : MonoBehaviour
    {
        public GameObject pillar;
        public GameObject coinSpawnner;

        Pillar pillars;

        private int minPillar;
        private int maxPillar;

		public void NewLevel()
		{
            transform.eulerAngles = Vector3.zero;
            Initialize();
		}

		public void Initialize()
		{
			int level = GameSceneService.Instance.LevelManager.CurrentLevel;
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

            for (int i = 0; i <= pillarAmount; i++)
            {
                pillars = GameSceneService.Instance.FactoryService.GetPillar();
                pillars.transform.parent = transform;
                pillars.transform.eulerAngles = Vector3.zero;
                pillars.transform.position = new Vector3(transform.position.x, i * 4, transform.position.z);
                SpwanCoinSpwaner(i);

                pillars.GetComponent<GroundManager>().Initialize(i == 0, i == pillarAmount);
            }

            //pillars = GameSceneService.Instance.FactoryService.GetPillar().gameObject;
            //lastpillar = pillarAmount * 4;
            ProgressBarScript.StartProgress();
            //pillars.transform.position = new Vector3(transform.position.x, lastpillar, transform.position.z);
            //pillars.transform.parent = transform;

			//pillars.GetComponent<GroundSpwanner>().Initialize(false, true);
		}

        private void SpwanCoinSpwaner(int i)
        {
            int isCoin = Random.Range(0, 2);

            if (isCoin == 1)
            {
                Coin coin = GameSceneService.Instance.FactoryService.GetCoin();
                coin.transform.parent = pillars.transform;
                coin.transform.position = pillars.transform.position;
                if (i == 0)
                    coin.transform.rotation = Quaternion.Euler(0, Random.Range(i == 0 ? 20 : 0, i == 0 ? 330 : 360), 0);
				//Instantiate(coinSpawnner, pillars.transform.position, Quaternion.identity, transform);

			}
        }

	}
}