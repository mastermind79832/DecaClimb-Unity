using Revity.Ads;
using System.Collections;
using UnityEngine;
using Revity.Core;
using Revity.DecaClimb.Persistant;

namespace Revity.DecaClimb.MainMenu
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
		}

		private void Start()
		{
			PersistantServiceLocator.Instance.ChangeCameraBg();			
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
			//LevelManager.ResetLevel();
			//LevelManager.isLevelUp = false;
			//LevelManager.isRetryUsed = false;

			PersistantServiceLocator.Instance.SceneService.LoadGameScene();
		}

		public void OpenUpgrade()
		{
			PersistantServiceLocator.Instance.SceneService.LoadUpgradeScene();
		}

	}
}
