using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText; 
    [SerializeField] private WeaponChanger weaponChanger;
    [SerializeField] private ArmaAutomatica[] weapons; 

    void Update()
    {
        
        int currentWeaponIndex = weaponChanger.GetCurrentWeaponIndex();
        ArmaAutomatica currentWeapon = weapons[currentWeaponIndex];

        
        ammoText.text = $"{currentWeapon.GetCurrentAmmo()}/{currentWeapon.GetReserveAmmo()}";
    }
}
