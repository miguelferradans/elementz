using Elementz.Elements.Data;
using Elementz.Spells.Data;
using System;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    protected void Start()
    {
        m_instantiatedTypeOne = InstantiateElementPrefab(m_typeOne, m_elementOneOffset);
        m_instantiatedTypeTwo = InstantiateElementPrefab(m_typeTwo, m_elementTwoOffset);
    }

    protected void Update()
    {
        ProcessInput();
    }

    protected void OnGUI()
    {
        if (m_castingSpell)
        {
            GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.1f, 150, 25), "" + m_currentCastTime + "/" + m_currentSpell.CastTime);
        }
    }

    private void ProcessInput()
    {
        if (Input.GetButtonDown("Fire1") || m_castingSpell)
        {
            m_currentSpell = GetSpellData();

            m_currentCastTime += Time.deltaTime;

            if (m_currentCastTime >= m_currentSpell.CastTime)
            {
                CastSpell(m_currentSpell);
                m_currentCastTime = 0f;
                m_castingSpell = false;
            }
            else
            {
                m_castingSpell = true;
            }

            Debug.Log("Casting spell");
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Stop casting");
            m_currentCastTime = 0f;
            m_castingSpell = false;
        }

        if (Input.GetButtonDown("ChangeElement1"))
        {
            m_typeOne =CycleElement(m_typeOne);
            Destroy(m_instantiatedTypeOne);
            m_instantiatedTypeOne = InstantiateElementPrefab(m_typeOne, m_elementOneOffset);
        }

        if (Input.GetButtonDown("ChangeElement2"))
        {
            m_typeTwo = CycleElement(m_typeTwo);
            Destroy(m_instantiatedTypeTwo);
            m_instantiatedTypeTwo = InstantiateElementPrefab(m_typeTwo, m_elementTwoOffset);
        }
    }

    private SpellData GetSpellData()
    {
        return m_castableSpells.GetSpell(m_typeOne, m_typeTwo);
    }

    private void CastSpell(SpellData spell)
    {
        GameObject spellObj = Instantiate(spell.SpellEffect);

        spellObj.transform.position = transform.position + (transform.forward * 5);
    }

    private GameObject InstantiateElementPrefab(ElementType type, Vector3 localPosition)
    {
        GameObject obj = null;

        if (type == ElementType.Ice)
        {
            obj = Instantiate(m_icePrefab, transform);
        }
        else if (type == ElementType.Stone)
        {
            obj = Instantiate(m_stonePrefab, transform);
        }

        if (null != obj)
        {
            obj.transform.localPosition = localPosition;
        }

        return obj;
    }

    private ElementType CycleElement(ElementType type)
    {
        ElementType[] elements = (ElementType[])Enum.GetValues(typeof(ElementType));

        type++;

        if ((int)type >= elements.Length)
        {
            type = 0;
        }

        return type;
    }

    [SerializeField]
    private CastableSpellsData m_castableSpells;

    [SerializeField]
    private GameObject m_icePrefab;

    [SerializeField]
    private GameObject m_stonePrefab;

    [SerializeField]
    private Vector3 m_elementOneOffset;

    [SerializeField]
    private Vector3 m_elementTwoOffset;

    private ElementType m_typeOne = ElementType.Ice;

    private ElementType m_typeTwo = ElementType.Ice;

    private GameObject m_instantiatedTypeOne;

    private GameObject m_instantiatedTypeTwo;

    private float m_currentCastTime;

    private bool m_castingSpell;

    private SpellData m_currentSpell;
}
