using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{

    public int Level;
    public GameObject Canvas;

    public void StartGame(){
        Canvas.SetActive(false);
        SceneManager.LoadScene(Level);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void LevelSelect(){
        SceneManager.LoadScene(Level);
    }

}
