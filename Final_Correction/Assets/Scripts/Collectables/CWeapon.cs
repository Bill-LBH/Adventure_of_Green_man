using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeapon : Collectables
{
    [SerializeField] private ItemData itemWeaponData;

    private CharacterWeapon weapon;

    protected override void Pick()
    {
        EquipWeapon();
    }

    private void EquipWeapon()
    {
        weapon = character.GetComponent<CharacterWeapon>();
        if (character != null)
        {
            if(weapon.SecondaryWeapon == null && weapon.ThirdWeapon == null && weapon.ForthWeapon == null)
            {
                weapon.SecondaryWeapon = itemWeaponData.WeaponToEquip;
            }
            
            else if(weapon.SecondaryWeapon != null && weapon.ThirdWeapon == null && weapon.ForthWeapon == null)
            {
                weapon.ThirdWeapon =itemWeaponData.WeaponToEquip;
            }
            
            else if(weapon.SecondaryWeapon !=null && weapon.ThirdWeapon != null && weapon.ForthWeapon == null)
            {
                weapon.ForthWeapon = itemWeaponData.WeaponToEquip;
            }
        }
    }    
}

