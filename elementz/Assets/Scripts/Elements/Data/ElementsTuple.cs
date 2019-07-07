using Elementz.Spells.Data;
using System;
using UnityEngine;

namespace Elementz.Elements.Data
{
    [Serializable]
    [CreateAssetMenu(menuName = "Elements/Elements Tuple")]
    public class ElementsTuple : ScriptableObject
    {
        public ElementType TypeOne { get { return m_typeOne; } }

        public ElementType TypeTwo { get { return m_typeTwo; } }

        public SpellData Spell { get { return m_spell; } }

        [SerializeField]
        private ElementType m_typeOne;

        [SerializeField]
        private ElementType m_typeTwo;

        [SerializeField]
        private SpellData m_spell;
    }
}
