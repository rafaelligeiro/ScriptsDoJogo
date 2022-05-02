using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBar : MonoBehaviour
{
  [SerializeField] private BulletsLife bullet;
  [SerializeField] private Image TotalBulletBar;
  [SerializeField] private Image currentBulletBar;

   private void Start()
    {
        TotalBulletBar.fillAmount = bullet.currentBullets / 10;
    }

    private void Update()
    {
        currentBulletBar.fillAmount = bullet.currentBullets / 10;
    }
}
