using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void LoadOption(int opt){
        if(opt==1){
            if(PlayerPrefs.GetInt("Index")>0){
                SceneManager.LoadScene(PlayerPrefs.GetInt("Index"));
            }else{
                SceneManager.LoadScene(3);
            }
        }else{
            SceneManager.LoadScene(opt-1);
        }
    }
}
