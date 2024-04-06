using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Revity.DecaClimb.Persistant
{
    /// <summary>
    /// A singleton that holds reference to all scene.
	/// Manages async scene transitions
    /// </summary>
    public class SceneService : MonoBehaviour
    {
		[SerializeField] private bool m_IsTesting;

		[Header("Data")]
		[SerializeField] private SceneDataSO m_SceneDataSO;
		private SceneAsset m_CurrentScene;

		[Header("Reference")]
		[SerializeField] private LoadingScreen m_LoadingScreen;
		[SerializeField] private Camera m_MainCamera;

		private AsyncOperation m_UnloadingSceneOperation;
		private AsyncOperation m_LoadingSceneOperation;

		private void Awake()
		{
			if (m_IsTesting)
			{
				m_CurrentScene = m_SceneDataSO.GameScene;
				return;
			}
            SceneManager.LoadScene(m_SceneDataSO.LogoIntroScene.name, LoadSceneMode.Additive);
			m_CurrentScene = m_SceneDataSO.LogoIntroScene;
		}

		private void LoadScene(SceneAsset scene)
		{
			m_LoadingScreen.StartLoadingScreen();

			m_UnloadingSceneOperation = SceneManager.UnloadSceneAsync(m_CurrentScene.name);
			m_LoadingSceneOperation = SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);

			StartCoroutine(LoadingScene(scene));
		}

		private IEnumerator LoadingScene(SceneAsset scene)
		{
			float progress;

            while (!m_LoadingSceneOperation.isDone && !m_UnloadingSceneOperation.isDone)
            {
				progress = (m_LoadingSceneOperation.progress + m_UnloadingSceneOperation.progress)/2;
				m_LoadingScreen.UpdateSlider(progress);			
				yield return null;        
			}

			m_LoadingScreen.LoadingComplete();
			m_CurrentScene = scene;
		}

		#region Specific Scene
		public void LoadMainMenuScene()
        {
            LoadScene(m_SceneDataSO.MainMenuScene);
        }

		public void LoadGameScene()
		{
			LoadScene(m_SceneDataSO.GameScene);
		}

		public void LoadUpgradeScene()
		{
			LoadScene(m_SceneDataSO.UpgradeScene);
		}
		#endregion
	}
}
