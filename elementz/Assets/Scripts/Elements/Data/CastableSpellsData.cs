using Elementz.Spells.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elementz.Elements.Data
{
    [Serializable]
    [CreateAssetMenu(menuName = "Spell/Castable Spells Data")]
    public class CastableSpellsData : ScriptableObject
    {
        public SpellData GetSpell(ElementType type1, ElementType type2)
        {
            foreach (ElementsTuple tuple in m_tuples)
            {
                if (tuple.TypeOne == type1 && tuple.TypeTwo == type2)
                {
                    return tuple.Spell;
                }
            }

            return null;
        }

        [SerializeField]
        private List<ElementsTuple> m_tuples;
    }
}
