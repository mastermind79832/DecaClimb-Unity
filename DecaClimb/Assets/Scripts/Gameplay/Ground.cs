using Revity.DecaClimb.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Revity.DecaClimb
{
    public class Ground : MonoBehaviour
    {
        private Pillar m_ParentPillar;
        private GroundType m_Type;
        public GroundType GroundType { get { return m_Type; } }

        [SerializeField] private MeshRenderer m_Mesh;

        public void InjectDependencies(Pillar pillar)
        {
            m_ParentPillar = pillar;
        }

        public void SetGroundType(GroundType type)
        {
            m_Type = type;
            Material Mat = GameSceneService.Instance.FactoryService.GetGround(type);
            m_Mesh.sharedMaterial = Mat;
        }

        public int GetLevel() => m_ParentPillar.PillarLevel;
    }
}
