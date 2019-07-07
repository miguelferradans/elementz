using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elementz.Spells.Data
{
    [Serializable]
    [CreateAssetMenu(menuName = "Spell/Ground AoE Spell")]
    public class GroundAoESpellData : SpellData
    {
        public Shape Shape { get { return m_shape; } }

        public Vector3 Scale { get { return m_scale; } }

        [SerializeField]
        private Shape m_shape;

        [SerializeField]
        private Vector3 m_scale;
    }

    public enum Shape
    {
        Sphere,
        Cube
    }
}
