﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider slider;
    public GameObject owner;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = owner.GetComponent<Pawn>().maxHeath;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = owner.GetComponent<Pawn>().currHealth;
    }
}
