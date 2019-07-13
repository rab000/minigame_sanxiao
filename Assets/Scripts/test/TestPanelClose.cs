using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPanelClose : UIPanel
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("Button").GetComponent<Button>().onClick.AddListener(()=>{
            
            UIManager.Ins.ClosePanel("test/TestPanel");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
