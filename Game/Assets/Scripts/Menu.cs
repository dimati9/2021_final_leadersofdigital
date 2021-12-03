using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSelect() {
            select.SetActive(true);
    }

    public void loadLevel1() {
        SceneManager.LoadSceneAsync("Level1Day");
    }
    public void loadLevel2() {
        SceneManager.LoadSceneAsync("Level1Night");
    }

    public void loadLevel3() {
        SceneManager.LoadSceneAsync("Level2Day");
    }
}
