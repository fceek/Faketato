using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BattleField : MonoBehaviour
{
    public static BattleField Instance;

    private float _top, _right, _bottom, _left;
    private Camera _mainCam;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _mainCam = Camera.main;
        Vector3 topRight = gameObject.GetComponent<SpriteRenderer>().bounds.max;
        Vector3 bottomLeft = gameObject.GetComponent<SpriteRenderer>().bounds.min;
        _top = topRight.y;
        _right = topRight.x;
        _bottom = bottomLeft.y;
        _left = bottomLeft.x;
        
        Debug.Log($"{_top}, {_right}, {_bottom}, {_left}");
    }

    public Vector3 GetRandomPoint()
    {
        Vector3 pixelPos =  new Vector3(Random.Range(_left, _right), Random.Range(_bottom, _top), 0);
        //Vector3 screenPos = _mainCam.ScreenToWorldPoint(pixelPos);
        //screenPos.z = 0;
        //return screenPos;
        return pixelPos;
    }
}
