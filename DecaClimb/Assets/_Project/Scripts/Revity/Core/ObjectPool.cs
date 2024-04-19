using System;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb.Core
{
    public class ObjectPool <T> where T : MonoBehaviour
    {
        private readonly List<T> m_Pool;
        private readonly Func<T> m_CreateFunc;

        /// <summary>
        /// Script that handles object pooling
        /// </summary>
        /// <param name="createFunc">Function that Creates the instance</param>
        /// <param name="minSize">Starting size of the pool. Default = 0</param>
        public ObjectPool(Func<T> createFunc, int minSize = 0)
        {
			m_CreateFunc = createFunc;
            m_Pool = new();

            if (minSize > 0)
            {
				CreateInitial(minSize);
            }
        }

		private void CreateInitial(int minSize)
		{
            for (int i = 0; i < minSize; i++)
                m_Pool.Add(m_CreateFunc());        
		}

        public T GetItem()
        {
            T item = m_Pool.Find(i => i.gameObject.activeSelf == false);
            if (item == null)
            {
                item = m_CreateFunc();
                m_Pool.Add(item);
            }
            item.gameObject.SetActive(true);
			return item;
        }

        public void PoolAll()
        {
            foreach (T item in m_Pool)
                item.gameObject.SetActive(false);
        }
	}
}
