using DecaClimb.Ads;
using System.Collections;
using UnityEngine;

namespace DecaClimb
{
    public class MainMenuService : MonoSingletonGeneric<MainMenuService>  
    {
		protected override void Awake()
		{
			base.Awake();
			StartCoroutine(DisplayBannerWithDelay());

			Camera.main.backgroundColor = BackgroundColorHandler.Instance.GetColorRandom();
		}

		private IEnumerator DisplayBannerWithDelay()
		{
			yield return new WaitForSeconds(1f);
			AdsManager.Instance.BannerAds.ShowAd();
		}

		private void Update()
		{
			CheckQuitGame();
		}

		private void CheckQuitGame()
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
			}
		}

		public void GameStart()
		{
			levelsHandle.ResetLevel();
			levelsHandle.isLevelUp = false;
			levelsHandle.isRetryUsed = false;

			PersistantSceneService.Instance.LoadGameScene();
		}

		public void OpenUpgrade()
		{
			PersistantSceneService.Instance.LoadUpgradeScene();
		}

	}
}
