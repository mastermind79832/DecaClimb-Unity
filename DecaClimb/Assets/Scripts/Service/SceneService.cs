using System;
using System.Collections;
using System.Collections.Generic;
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
		private SceneAsset m_CurrentScene;

		[Header("Helper Screen")]
		[SerializeField] private LoadingScreen m_LoadingScreen;

		private List<AsyncOperation> m_AsyncOperations;

		public event Action OnSceneLoadingStart;
		public event Action OnSceneLoadingComplete;

		override protected void Awake()
		{
			base.Awake();
			m_AsyncOperations = new();
		}

		private void Start()
		{
			SceneManager.LoadScene(m_LogoIntroScene.name, LoadSceneMode.Additive);
			m_CurrentScene = m_LogoIntroScene;
		}

		private void LoadScene(SceneAsset scene)
		{
			m_LoadingScreen.StartLoadingScreen();
			m_AsyncOperations.Clear();

			StartCoroutine(LoadingScene(scene));
		}

		private IEnumerator LoadingScene(SceneAsset scene)
		{
			m_AsyncOperations.Add(SceneManager.UnloadSceneAsync(m_CurrentScene.name));
			m_AsyncOperations.Add(SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive));
			OnSceneLoadingStart();

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

			OnSceneLoadingComplete();
			m_LoadingScreen.LoadingComplete();
			m_CurrentScene = scene;
		}

		#region Specific Scene
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
