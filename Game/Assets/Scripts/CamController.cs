using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CamController : MonoBehaviour
{
    public GameObject loseCam;
    public GameObject finalLoseScreen;
    private bool lose = false;

    public Text pointsText;
    public Text speedText;
    public Text heightText;
    public GameObject[] cams;
    public GameObject[] checkpoints;

    public Material colorCheckPoint;
    public Material colorCurrentCheckPoint;

    public int checkpointNeed = 0;
    public int currentCam = 0;

    private int allPoints = 0;
    private int setPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        cams[currentCam].SetActive(true);
        checkpoints[0].GetComponent<MeshRenderer>().material = colorCurrentCheckPoint;
        allPoints = checkpoints.Length;
        pointsText.text = "Чекпоинты: " + setPoints + " / " + allPoints;
        checkpoints[checkpoints.Length-1].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
            Debug.Log("currentCam: " + currentCam);
            cams[currentCam].GetComponent<Camera>().enabled = false;
            if(currentCam >= cams.Length-1) {
                currentCam = 0;
            }   else {
                currentCam++;
            }
            cams[currentCam].GetComponent<Camera>().enabled = true;
        }
        heightText.text = "Высота: " + Mathf.Round(transform.position.y) + "м";
        speedText.text = "Скорость: " + Mathf.Round(gameObject.GetComponent<Rigidbody>().velocity.magnitude) + "км/ч";
        
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(other.tag);  
        if(other.tag == "sphere") {
                if(other.gameObject == checkpoints[checkpointNeed]) {
            Destroy(other.gameObject);
            checkpointNeed++;
            setPoints++;
            pointsText.text = "Чекпоинты: " + setPoints + " / " + allPoints;
            if(checkpointNeed == checkpoints.Length-1) {
                checkpoints[checkpoints.Length-1].SetActive(true);
            }   else {
                checkpoints[checkpointNeed].GetComponent<MeshRenderer>().material = colorCurrentCheckPoint;
            }
          
        } 
        }   else if(other.tag == "enemy") {
            gameObject.GetComponent<DroneMovement>().enabled = false;
             StartCoroutine(Lose(2.0f));
             gameObject.transform.Rotate(-180.0f, 0.0f, 0.0f);
             cams[currentCam].GetComponent<Camera>().enabled = false;
             cams[currentCam].SetActive(false);
             loseCam.GetComponent<Camera>().enabled = true;
        }
        
    }

    public void Restart() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

   

    IEnumerator Lose(float timer){
    yield return new WaitForSeconds(timer);
            finalLoseScreen.SetActive(true);
    }
}
