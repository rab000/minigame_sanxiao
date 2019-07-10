using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPanel2 : UIPanel
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Button").GetComponent<Button>().onClick.AddListener(()=>{
            
            UIManager.GetIns().ClosePanel("TestPanel2");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
