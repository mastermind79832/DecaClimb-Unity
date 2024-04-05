using Revity.Ads;
using System.Collections;
using UnityEngine;
using Revity.Core;
using Revity.DecaClimb.Persistant;

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

			PersistantServiceLocator.Instance.Camera.backgroundColor = PersistantServiceLocator.Instance.DataHandler.BackgroundColor.GetColorRandom();
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

			PersistantServiceLocator.Instance.SceneService.LoadGameScene();
		}

		public void OpenUpgrade()
		{
			PersistantServiceLocator.Instance.SceneService.LoadUpgradeScene();
		}

	}
}
