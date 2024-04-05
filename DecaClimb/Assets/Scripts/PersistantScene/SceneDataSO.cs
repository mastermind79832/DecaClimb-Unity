using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Revity.DecaClimb
{
	[CreateAssetMenu(fileName="Scene Data", menuName="DataSO/Scene")]
    public class SceneDataSO : ScriptableObject
    {
		public SceneAsset LogoIntroScene;
		public SceneAsset MainMenuScene;
		public SceneAsset GameScene;
		public SceneAsset UpgradeScene;
	}
}
