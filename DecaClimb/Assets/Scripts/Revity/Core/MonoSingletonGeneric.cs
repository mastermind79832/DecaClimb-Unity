using UnityEngine;

namespace Revity.Core
{
	/// <summary>
	/// Class used to make singletons
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class MonoSingletonGeneric<T> : MonoBehaviour where T : MonoSingletonGeneric<T>
	{
		private static T m_Instance;
		public static T Instance { get { return m_Instance; } }

		protected virtual void Awake()
		{
			if (m_Instance != null)
			{
				Destroy(this.gameObject);
				return;
			}
			m_Instance = (T)this;
		}
	}
}