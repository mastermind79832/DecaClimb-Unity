using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DecaClimb
{
    /// <summary>
    /// A singleton that holds reference to all scene.
	/// Manages async scene transitions
    /// </summary>
    public class PersistantSceneService : MonoSingletonGeneric<PersistantSceneService>
    {
		[Header("Scene")]
        [SerializeField] private SceneAsset m_LogoIntroScene;
        [SerializeField] private SceneAsset m_MainMenuScene;
		[SerializeField] private SceneAsset m_GameScene;
		[SerializeField] private SceneAsset m_UpgradeScene;
		private SceneAsset m_CurrentScene;

		[Header("Helper")]
		[SerializeField] private LoadingScreen m_LoadingScreen;

		[SerializeField] private Camera m_MainCamera;
		public Camera MainCamera { get { return m_MainCamera; } }

		private List<AsyncOperation> m_AsyncOperations;

		public event Action OnSceneLoadingStart;
		public event Action OnSceneLoadingComplete;

		override protected void Awake()
		{
			base.Awake();
			m_AsyncOperations = new();
			SceneManager.LoadScene(m_LogoIntroScene.name, LoadSceneMode.Additive);
			m_CurrentScene = m_LogoIntroScene;
		}

		private void LoadScene(SceneAsset scene)
		{
			m_LoadingScreen.StartLoadingScreen();
			m_AsyncOperations.Clear();
			m_AsyncOperations.Add(SceneManager.UnloadSceneAsync(m_CurrentScene.name));
			m_AsyncOperations.Add(SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive));
			StartCoroutine(LoadingScene());
			m_CurrentScene = scene;
		}

		private IEnumerator LoadingScene()
		{
			OnSceneLoadingStart?.Invoke();

			bool isDone = false;
			float progress;

            while (!isDone)
            {
				isDone = true;
				progress = 0;
                foreach (AsyncOperation operation in m_AsyncOperations)
				{
					if (!operation.isDone)
						isDone = false;

					progress += operation.progress;
				}

				m_LoadingScreen.UpdateSlider(progress/m_AsyncOperations.Count);
				
				yield return null;
            
			}

			OnSceneLoadingComplete?.Invoke();
			m_LoadingScreen.LoadingComplete();
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
