using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSprRender : MonoBehaviour
{
    
    void Start()
    {
        var sr = gameObject.GetComponent<SpriteRenderer>();

        Debug.Log("size:"+sr.size);

    }

}
