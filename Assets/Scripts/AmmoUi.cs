using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText; 
    [SerializeField] private WeaponChanger weaponChanger;
    [SerializeField] private Arma[] weapons;

    int currentWeaponIndex;
    Arma currentWeapon;

    void Update()
    {
        
        currentWeaponIndex = weaponChanger.GetCurrentWeaponIndex();
        currentWeapon = weapons[currentWeaponIndex];

        
        ammoText.text = "" + currentWeapon.BalasActualesCargador + "/" + currentWeapon.BalasActualesBolsa;
    }
}
