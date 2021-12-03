using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class help : MonoBehaviour
{
    public GameObject helper;
    public GameObject drone;
    public int currentPanel = 0;
    public GameObject[] panels;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    
    }

    public void Skip() {
        helper.SetActive(false);
        drone.SetActive(true);
    }

    public void NextPanel() {
            if(currentPanel < panels.Length-1) {
                panels[currentPanel].SetActive(false);
                currentPanel++;
                panels[currentPanel].SetActive(true);
            }   else {
                helper.SetActive(false);
                drone.SetActive(true);
            }
    }
}
