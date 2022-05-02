using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectProguessBar : MonoBehaviour
{

   public Slider staminaBar;

   private int maxStamina = 100;
   private int currentStamina;

   private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
   private Coroutine regen;
   
   public static ProtectProguessBar instance;

   public PlayerProtect Ref;

   private void Awake()
      {
        instance = this;
      }


      void Start()
         {
            currentStamina = maxStamina;
            staminaBar.maxValue = maxStamina;
            staminaBar.value = maxStamina;
         }

      public void UseStamina(float amount)
         {
            if(currentStamina - amount >= 0)
               {
                  currentStamina -= maxStamina / 100;
                  staminaBar.value = currentStamina;

                  if(regen != null)
                     {
                        StopCoroutine(regen);
                     }
                 regen = StartCoroutine(RegenStamina());
               } else{

                  StartCoroutine(AnimStopFix());
                  Debug.Log("Can't protect!");
               }
         }


      IEnumerator AnimStopFix()
         {
         yield return new WaitForSeconds(1f);
         Ref.GetComponent<PlayerProtect>().enabled = false;
         }



      IEnumerator RegenStamina() 
         {
            yield return new WaitForSeconds(2f);

            while (currentStamina < maxStamina)
               {
                  currentStamina += maxStamina / 100;
                  staminaBar.value = currentStamina;
                  yield return regenTick;
                  Ref.GetComponent<PlayerProtect>().enabled = true;
               }

            regen = null;
         }
}