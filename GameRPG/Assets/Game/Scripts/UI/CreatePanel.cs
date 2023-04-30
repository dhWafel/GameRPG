using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePanel : MonoBehaviour{
    [SerializeField]
    private GameObject m_mainWeapon;
    [SerializeField]
    private GameObject m_mainArmor;
    //[SerializeField]
    //private GameObject m_mainAccessories;
    [SerializeField]
    private GameObject m_mainPoition;

    [SerializeField]
    private GameObject m_firstType;
    [SerializeField]
    private GameObject m_secondType;
    [SerializeField]
    private GameObject m_thirdType;
    [SerializeField]
    private GameObject m_fourthType;
    [SerializeField]
    private GameObject m_fifthType;

    private void Start() {  

    }

    public void ShowWeaponPanel(int type) {
        m_mainWeapon.SetActive(false);
        if (type == 0) {
            m_firstType.SetActive(true);
        }
        if(type == 1) {
            m_secondType.SetActive(true);
        }
        if(type == 2) {
            m_thirdType.SetActive(true);
        }
        if(type == 3) {
            m_fourthType.SetActive(true);
        }
        if(type == 4) {
            m_fifthType.SetActive(true);
        }
    }

    private void TurnOff() {
        m_firstType.SetActive(false);
        m_secondType.SetActive(false);
        m_thirdType.SetActive(false);
        m_fourthType.SetActive(false);
        m_fifthType.SetActive(false);
    }

    private void OnEnable() {
        TurnOff();
        m_mainWeapon.SetActive(true);
    }

    private void OnDisable() {
        
    }
}