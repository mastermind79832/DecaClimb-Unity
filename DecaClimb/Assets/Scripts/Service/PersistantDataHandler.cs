using System;
using System.Diagnostics.Tracing;
using UnityEngine;

namespace DecaClimb
{
    public class PersistantDataHandler : MonoSingletonGeneric<PersistantDataHandler>
    {
        [SerializeField] private StatsManager m_ProgressManager;
        public StatsManager ProgressManager { get { return m_ProgressManager; } }

        [SerializeField] private SettingsManager m_SettingsManager;
        public SettingsManager SettingsManager { get { return m_SettingsManager; } }

        [SerializeField] private EconomyManager m_EconomyManager;
        public EconomyManager EconomyManager { get { return m_EconomyManager;} }
		
		override protected void Awake()
		{
			base.Awake();
			SettingsManager.LoadSetting();
		}

		public void OnNewInstall()
		{
			m_ProgressManager.NewInstall();
			m_EconomyManager.NewInstall();
			// Show tutorial
		}

		public void OnVersionUpdated()
		{
			// show update log
			
		}

		public void OnSettingsLoaded()
		{
			m_ProgressManager.ReturningUser();
			m_EconomyManager.ReturningUser();
		}
	}
}
