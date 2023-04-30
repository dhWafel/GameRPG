﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _Instance;
    public static T Instance {
        get {
            if (_Instance == null) {
                _Instance = FindObjectOfType<T>();
            }
            return _Instance;
        }
    }
    private void Awake(){
        OnAwake();
    }
    protected virtual void OnAwake(){ 
        
    }
}
