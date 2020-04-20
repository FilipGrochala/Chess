﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Card : MonoBehaviour
{
    public GameObject prefab;

    public event Action onClicked;

    Camera camera;


    void Awake()
    {
        camera = FindObjectOfType<Camera>();
    }
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition); // jeżeli po wciśnięciu przycisku kursor będzie nad kartą
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 25.0f,
            LayerMask.GetMask("Cards")))
        {
            Debug.Log("click");

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("click");
                onClicked.Invoke();
            }

        }
    }
}