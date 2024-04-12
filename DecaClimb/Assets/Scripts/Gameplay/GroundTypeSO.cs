using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb
{
	public enum GroundType
	{
		Normal = 0,
		Danger = 1,
		Goal = 2,
		Empty = -1
	}

	[Serializable]
	public struct GroundTypeMaterial
	{
		public GroundType Type;
		public Material Material;
	}

    [CreateAssetMenu(fileName ="Ground Type", menuName = "DataSO/Ground")]
	public class GroundTypeSO : ScriptableObject
    {
		[SerializeField] private List<GroundTypeMaterial> GroundTypeMats;
		
		public GroundTypeMaterial GetGroundTypeMaterial(GroundType type)
		{
			return GroundTypeMats.Find(x => x.Type == type);
		}
    }
}
