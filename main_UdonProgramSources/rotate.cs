﻿
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class rotate : UdonSharpBehaviour
{
    public float RotateSpeed;
    void Update()
    {
        this.gameObject.transform.Rotate(this.gameObject.transform.up * RotateSpeed * Time.deltaTime);
    }
}
