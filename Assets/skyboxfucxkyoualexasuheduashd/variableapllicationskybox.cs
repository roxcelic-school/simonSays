using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

public class variableapllicationskybox : MonoBehaviour {
    [SerializeField] Renderer targetRenderer;
    [SerializeField] int defaultValue = 10;
    [SerializeField] bool hoiii = false;
    
    [Header("conf (doesnt matter if hoiii is false)")]
    public float MaxRoom = 10f;
    public float MinRoom = 0f;
    public float Room = 0f;

    void Start() {
        targetRenderer.material.SetFloat("_speed", PlayerPrefs.GetInt("skyboxspeed", defaultValue) == 0 ? 0.5f : PlayerPrefs.GetInt("skyboxspeed", defaultValue));
        targetRenderer.material.SetFloat("_room", PlayerPrefs.GetInt("floor", defaultValue));
        Room = PlayerPrefs.GetInt("floor", defaultValue);
    
        if (hoiii) StartCoroutine(updateDisplay());
    }

    public IEnumerator updateDisplay() {
        while (true) {
            targetRenderer.material.SetFloat("_speed", PlayerPrefs.GetInt("skyboxspeed", defaultValue) == 0 ? 0.5f : PlayerPrefs.GetInt("skyboxspeed", defaultValue));
        
            targetRenderer.material.SetFloat("_room", Room);
            
            // hehehehaw
            Room += 0.25f;
            if (Room > MaxRoom) Room = MinRoom;

            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
}
