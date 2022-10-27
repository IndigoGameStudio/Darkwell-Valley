using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsSystem : MonoBehaviour
{
    // skripta za glavne stvari o igracu
 
    public Slider HealthBar;
    public Slider HungerBar;
    public Slider StaminaBar;

    public float Health = 1;
    public float Hunger = 0.7f;
    public float Stamina = 1;
   
    public void Update()
    {
        
    }
}
