using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActivation : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] public GameObject weapon;

    public void Buying_Weapon()
    {
        int coin = CoinManager.Instance.CoinsGetter();
        if (coin >= price)
        {
            weapon.SetActive(true);
            CoinManager.Instance.RemoveCoins(price);
        }
    }

}
