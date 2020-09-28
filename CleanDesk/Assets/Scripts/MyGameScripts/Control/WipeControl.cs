﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeControl : MonoBehaviour
{
    Vector3 originP = new Vector3(0, 0, 0);
    bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        originP = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Obj")
        {
            Debug.Log("test1234");
            Destroy(other.gameObject.transform.parent.gameObject);
            if (!isPlaying)
            {
                isPlaying = true;
                GameEventCenter.DispatchEvent("timerStart");
            }
           // isPlaying = true;
        }
    }
}