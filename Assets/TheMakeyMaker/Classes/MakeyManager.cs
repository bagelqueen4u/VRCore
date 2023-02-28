using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeyManager : Singleton<MakeyManager>
{
    public enum Key{UpArrow, DownArrow, LeftArrow, RightArrow, Space, Click, LeftCLick, F, G, W, S, A, D}

    private Dictionary<Key, KeyCode> _mapping;
    
    protected override void Init()
    {
        _mapping = new Dictionary<Key, KeyCode>();
        
        //======= MakeyMakey mapping ========
        _mapping[Key.UpArrow] = KeyCode.UpArrow;
        _mapping[Key.DownArrow] = KeyCode.DownArrow;
        _mapping[Key.LeftArrow] = KeyCode.LeftArrow;
        _mapping[Key.RightArrow] = KeyCode.RightArrow;
        _mapping[Key.Space] = KeyCode.Space;
        _mapping[Key.Click] = KeyCode.Mouse0;
        _mapping[Key.LeftCLick] = KeyCode.Mouse1;
        _mapping[Key.F] = KeyCode.F;
        _mapping[Key.G] = KeyCode.G;
        _mapping[Key.W] = KeyCode.W;
        _mapping[Key.S] = KeyCode.S;
        _mapping[Key.A] = KeyCode.A;
        _mapping[Key.D] = KeyCode.D;
    }

    public void RemapKey(Key key, KeyCode keycode)
    {
        _mapping[key] = keycode;
    }
    
    public bool GetKey(Key key)
    {
        return Input.GetKey(_mapping[key]);
    }

    public bool GetKeyDown(Key key)
    {
        return Input.GetKeyDown(_mapping[key]);
    }

    public bool GetKeyUp(Key key)
    {
        return Input.GetKeyUp(_mapping[key]);
    }
}
