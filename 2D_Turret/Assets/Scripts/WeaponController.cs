using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret2d
{
    public class WeaponController : MonoBehaviour
    {
        int totalWeapons = 1;
        public int currentWeaponIndex;

        public GameObject[] guns;
        public GameObject weaponHolder;
        public GameObject currentGun;

        private void Start()
        {
            totalWeapons = weaponHolder.transform.childCount;
            guns = new GameObject[totalWeapons];

            for (int i = 0; i < totalWeapons; i++)
            {
                guns[i] = weaponHolder.transform.GetChild(i).gameObject;
                guns[i].SetActive(false);

            }

            guns[0].SetActive(true);
            currentGun = guns[0];
            currentWeaponIndex = 0;

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeaponIndex < totalWeapons - 1)
                {
                    guns[currentWeaponIndex].SetActive(false);
                    currentWeaponIndex += 1;
                    guns[currentWeaponIndex].SetActive(true);
                    currentGun = guns[currentWeaponIndex];
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (currentWeaponIndex > 0)
                {
                    guns[currentWeaponIndex].SetActive(false);
                    currentWeaponIndex -= 1;
                    guns[currentWeaponIndex].SetActive(true);
                    currentGun = guns[currentWeaponIndex];
                }
            }
        }

    }

}
