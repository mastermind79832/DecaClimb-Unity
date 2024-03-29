using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DecaClimb
{
    /// <summary>
    /// Holds reference to all scene
    /// </summary>
    public class SceneService : MonoSingletonGeneric<SceneService>
    {
		[Header("Scene")]
        [SerializeField] private SceneAsset m_LogoIntroScene;
        [SerializeField] private SceneAsset m_MainMenuScene;
		[SerializeField] private SceneAsset m_GameScene;
		[SerializeField] private SceneAsset m_UpgradeScene;
		private SceneAsset s_CurrentScene;

		[Header("Helper Screen")]
		[SerializeField] private LoadingScreen m_LoadingScreen;

		private List<AsyncOperation> m_AsyncOperations = new();

		private void LoadScene(SceneAsset scene)
		{
			m_LoadingScreen.StartLoadinScreen();
			m_AsyncOperations.Clear();

			StartCoroutine(LoadingScene(scene));
		}

		private IEnumerator LoadingScene(SceneAsset scene)
		{
			m_AsyncOperations.Add(SceneManager.UnloadSceneAsync(s_CurrentScene.name));
			m_AsyncOperations.Add(SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive));

			bool isDone = false;
			float progress;

            while (!isDone)
            {
				isDone = true;
				progress = 0;
                foreach (var operation in m_AsyncOperations)
				{
					if (!operation.isDone)
						isDone = false;

					progress += operation.progress;
				}

				m_LoadingScreen.UpdateSlider(progress/m_AsyncOperations.Count);
				
				yield return null;
            
			}

			m_LoadingScreen.LoadingComplete();
			s_CurrentScene = scene;
		}

		#region Specific Scene
		public void LoadIntroScene()
		{
			LoadScene(m_LogoIntroScene);
		}
		public void LoadMainMenuScene()
        {
            LoadScene(m_MainMenuScene);
        }

		public void LoadGameScene()
		{
			LoadScene(m_GameScene);
		}

		public void LoadUpgradeScene()
		{
			LoadScene(m_UpgradeScene);
		}
		#endregion
	}
}
