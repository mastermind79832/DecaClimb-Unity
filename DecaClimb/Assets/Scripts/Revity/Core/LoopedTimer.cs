using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Revity.DecaClimb.Core
{
    /// <summary>
    /// Script that handles Timed events
    /// </summary>
    public class LoopedTimer
    {
        private float m_CurrentTime;
        private readonly float m_TimePeriod;

        private readonly Action m_OnTimerEnd;
        private readonly Action<float> m_OnTimerTick;

        public bool IsPaused;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timePeriod">Max timer for timer</param>
        /// <param name="onTimerEnd">Called when timer ends</param>
        /// <param name="onTimerTick">Called every timer update</param>
        public LoopedTimer(float timePeriod, Action onTimerEnd, Action<float> onTimerTick = null)
		{
			m_TimePeriod = timePeriod;
			m_OnTimerEnd = onTimerEnd;
			m_OnTimerTick = onTimerTick;

			ResetCurrentTime();
			IsPaused = false;
		}

		private void ResetCurrentTime()
		{
			m_CurrentTime = 0;
		}

		/// <summary>
		/// Moves the timer
		/// </summary>
		/// <param name="deltaTime">how much time have passed</param>
		public void Tick(float deltaTime)
        {
            if (IsPaused) { return; }

            m_CurrentTime += deltaTime;
            m_OnTimerTick?.Invoke(m_CurrentTime);

            if (m_CurrentTime >= m_TimePeriod)
            {
                m_OnTimerEnd();
                ResetCurrentTime();
            }
        }
    }
}
