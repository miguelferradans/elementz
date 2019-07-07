using System;
using UnityEngine;

namespace Elementz.Spells.Data
{
    [Serializable]
    [CreateAssetMenu(menuName = "Spell/Generic Spell")]
    public class SpellData : ScriptableObject
    {
        public float CastTime { get { return m_castTime; } }

        public float TravelSpeed { get { return m_travelSpeed; } }

        public GameObject TravelEffect { get { return m_travelEffect; } }

        public GameObject SpellEffect { get { return m_spellEffect; } }

        public DamageType DamageType { get { return m_damageType; } }

        public float Damage { get { return m_damage; } }

        public PlayerModificationType PlayerModification { get { return m_playerModType; } }

        public float Intensity { get { return m_intensity; } }

        public float Duration { get { return m_duration; } }


        [SerializeField]
        private float m_castTime;

        [SerializeField]
        private float m_travelSpeed;

        [SerializeField]
        private GameObject m_travelEffect;

        [SerializeField]
        private GameObject m_spellEffect;

        [SerializeField]
        private DamageType m_damageType;

        [SerializeField]
        private float m_damage;

        [SerializeField]
        private PlayerModificationType m_playerModType;

        [SerializeField]
        private float m_intensity;

        [SerializeField]
        private float m_duration;
    }
}
