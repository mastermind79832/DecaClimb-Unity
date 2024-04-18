using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Revity.DecaClimb
{
	[CreateAssetMenu(fileName="Scene Data", menuName="DataSO/Scene")]
    public class SceneDataSO : ScriptableObject
    {
#if UNITY_EDITOR
		public SceneAsset LogoIntroSceneRef;
		public SceneAsset MainMenuSceneRef;
		public SceneAsset GameSceneRef;
		public SceneAsset UpgradeSceneRef;

		[ContextMenu("Add Scene Names")]
		public void AddReferences()
		{
			LogoIntroScene = LogoIntroSceneRef.name;
			MainMenuScene = MainMenuSceneRef.name;
			GameScene = GameSceneRef.name;
			StoreScene = UpgradeSceneRef.name;
		}
#endif
		public string LogoIntroScene;
		public string MainMenuScene;
		public string GameScene;
		public string StoreScene;
	}
}
