using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
   [SerializeField] private BossHealth bossHealth;
   [SerializeField] private Image TotalBossBar;
   [SerializeField] private Image currentBossBar;

   private void Start()
    {
        TotalBossBar.fillAmount = bossHealth.vidaAtual / 10;
    }

    private void Update()
    {
        currentBossBar.fillAmount = bossHealth.vidaAtual / 10;
    }
}
