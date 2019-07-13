using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : MonoBehaviour
{

    public int Type;

    public int GridX;

    public int GridY;

    public Vector2 Pos;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        
    }

    void Init()
    {
        
    }

    void Dispose()
    {
        Type = -1;

        GridX = -1;

        GridY = -1;

        Pos = Vector2.zero;

    }

}
