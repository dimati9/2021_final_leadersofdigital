using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class help : MonoBehaviour
{
    private bool firstC = true;
    private bool firstJ = true;
    private bool firstW = true;
    public GameObject[] Helps; 
    private int currentHelp = 0;
    private bool firstI = true;
    public GameObject helper;
    public GameObject drone;
    public int currentPanel = 0;
    public GameObject[] panels;
    private GameObject spark;
    // Start is called before the first frame update
    void Start()
    { 
       spark =  drone.GetComponent<DroneCollision>().sparks;
       drone.GetComponent<DroneCollision>().sparks = null;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.I) && firstI) { 
            drone.GetComponent<DroneCollision>().sparks = spark;
            drone.GetComponent<DronePropelers>().enabled = true;
            drone.GetComponent<DroneMovement>().enabled = true;
            firstI = false;
             StartCoroutine(Next(1.1f));
         }
         if((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.L)) && firstJ) { 
            firstJ = false;
             StartCoroutine(Next(1.1f));
         }
         if(Input.GetKeyDown(KeyCode.C) && firstC) { 
            firstC = false;
            StartCoroutine(Next(1.1f));
         }
         if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && firstW) { 
            firstW = false;
           StartCoroutine(Next(1.1f));
         }
    
    }

    IEnumerator Next(float timer){
    yield return new WaitForSeconds(timer);
           if(currentHelp < Helps.Length-1) {
                Helps[currentHelp].SetActive(false);
            currentHelp++;
            Helps[currentHelp].SetActive(true);
           }    else {
               Helps[currentHelp].SetActive(false);
           }
    }

    public void Skip() {
        helper.SetActive(false);
        drone.SetActive(true);
        Helps[currentHelp].SetActive(true);
    }

    public void NextPanel() {
            if(currentPanel < panels.Length-1) {
                panels[currentPanel].SetActive(false);
                currentPanel++;
                panels[currentPanel].SetActive(true);
            }   else {
                helper.SetActive(false);
                drone.SetActive(true);
                 Helps[currentHelp].SetActive(true);
            }
    }
}
