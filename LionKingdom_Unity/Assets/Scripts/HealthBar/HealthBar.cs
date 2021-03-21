using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //in order to create variable to store slider


public class HealthBar : MonoBehaviour
{

  public Slider slider;

public void SetHealth(int health)
{
  slider.value = health;
}
}
