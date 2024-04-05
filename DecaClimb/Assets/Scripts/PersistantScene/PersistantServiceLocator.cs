using Revity.Core;
using UnityEngine;

namespace Revity.DecaClimb.Persistant
{
    /// <summary>
    /// locator for all scripts in the persistant scene
    /// </summary>
    public class PersistantServiceLocator : MonoSingletonGeneric<PersistantServiceLocator>
    {
        [SerializeField] private SceneService m_SceneService;
        public SceneService SceneService { get { return m_SceneService; } }

        private DataHandler m_DataHandler;
        public DataHandler DataHandler { get {  return m_DataHandler; } }

        [SerializeField] private Camera m_Camera;
        public Camera Camera { get { return m_Camera;} }

        [SerializeField] private BackgroundColorHandlerSO m_ColorSO;

		override protected void Awake()
		{
            base.Awake();
			Application.targetFrameRate = 90;
			CreateService();
		}

		private void CreateService()
		{
			m_DataHandler = new DataHandler(m_ColorSO);
		}
	}
}
