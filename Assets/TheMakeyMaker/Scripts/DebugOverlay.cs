using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DebugOverlay : MonoBehaviour
{
    public enum DebugOverlayState{Visible, Invisible};
    
    public DebugOverlayState defaultState;
    public KeyCode triggerKey;
    private Canvas _canvas;

    void SetState(bool state)
    {
        _canvas.enabled = state;
    }
    
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        SetState(defaultState == DebugOverlayState.Visible);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            SetState(!_canvas.isActiveAndEnabled);
        }
    }
}
