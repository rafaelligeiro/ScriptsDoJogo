using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtectProguessBar : MonoBehaviour
{

   public Slider staminaBar;

   private int maxStamina = 100;
   private int currentStamina;

   private WaitForSeconds regenTick = new WaitForSeconds(.1f);
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

      public void UseStamina(int amount)
         {
            if(currentStamina - amount >= 0)
               {
                  currentStamina -= amount;
                  staminaBar.value = currentStamina;
         }
         }



        public void AddStamina(int _value)
         {
         currentStamina = Mathf.Clamp(currentStamina + _value, 0, maxStamina);
         }
}