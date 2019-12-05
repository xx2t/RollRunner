using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuControl : MonoBehaviour
{
    public void LoadOption(int opt){
        if(opt==1){
            if(PlayerPrefs.GetInt("Index")>0){
                SceneManager.LoadScene(PlayerPrefs.GetInt("Index"));
            }else{
                SceneManager.LoadScene(3);
            }
        }else if (opt==2){
            SceneManager.LoadScene(1);
        }else if (opt==3){
            SceneManager.LoadScene(2);
        }else if (opt==4){
            SceneManager.LoadScene(0);
        }
    }
    public void SetActiveAbility(int ability){
        if(PlayerPrefs.GetInt("jUnlocked")==0&&ability==1){
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-9);
        }
        if(PlayerPrefs.GetInt("tUnlocked")==0&&ability==2){
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-18);
        }
        if(PlayerPrefs.GetInt("lUnlocked")==0&&ability==3){
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-12);
        }
        PlayerPrefs.SetInt("ActiveAbility",ability);
        if(ability==1){
            PlayerPrefs.SetInt("jUnlocked",1);
        }else if(ability==2){
            PlayerPrefs.SetInt("tUnlocked",1);
        }else if (ability==3){
            PlayerPrefs.SetInt("lUnlocked",1);
        }
    }
    void Update(){
        if(SceneManager.GetActiveScene().buildIndex==1){
            Button jOpt = GameObject.Find("Jump").GetComponent<Button>();
            Button tOpt = GameObject.Find("Teleport").GetComponent<Button>();
            Button lOpt = GameObject.Find("ExtraLife").GetComponent<Button>();
            TextMeshProUGUI coins = GameObject.Find("CoinCount").GetComponent<TextMeshProUGUI>();
            coins.text=""+Mathf.Floor(PlayerPrefs.GetInt("Coins")/3);
            if(PlayerPrefs.GetInt("Coins")>=9||PlayerPrefs.GetInt("jUnlocked")==1){
                jOpt.interactable=true;
            }else{
                jOpt.interactable=false;
            }
            if(PlayerPrefs.GetInt("Coins")>=18||PlayerPrefs.GetInt("tUnlocked")==1){
                tOpt.interactable=true;
            }else{
                tOpt.interactable=false;
            }
            if(PlayerPrefs.GetInt("Coins")>=12||PlayerPrefs.GetInt("lUnlocked")==1){
                lOpt.interactable=true;
            }else{
                lOpt.interactable=false;
            }
        }
    }
}
