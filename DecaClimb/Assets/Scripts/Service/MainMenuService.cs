using Revity.Ads;
using System.Collections;
using UnityEngine;
using Revity.Core;
using Revity.DecaClimb;

namespace Revity.DecaClimb
{
	/// <summary>
	/// Service that handles the Main menu.
	/// </summary>
    public class MainMenuService : MonoSingletonGeneric<MainMenuService>  
    {
		protected override void Awake()
		{
			base.Awake();
			StartCoroutine(DisplayBannerWithDelay());

			PersistantSceneService.Instance.MainCamera.backgroundColor = BackgroundColorHandler.Instance.GetColorRandom();
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
