using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    void Awake(){
        GameObject[] objs=GameObject.FindGameObjectsWithTag("Music");
        if(objs.Length>1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public int mainMenuIndex;
    public int world1Index;
    public int world2Index;
    public int world3Index;

    public List<AudioClip> songs = new List<AudioClip>();
    private AudioSource aud;
    void Start(){
        aud=this.GetComponent<AudioSource>();
        aud.clip=songs[0];
        aud.Play();
    }
    public IEnumerator StartNextLevel(){
        yield return new WaitForSeconds(0.5f);
        int currentIndex= SceneManager.GetActiveScene().buildIndex;
        if(currentIndex==mainMenuIndex){
            aud.clip=songs[0];
            aud.Play();
        }
        if(currentIndex==world1Index){
            aud.clip=songs[1];
            aud.Play();
        }
        if(currentIndex==world2Index){
            aud.clip=songs[2];
            aud.Play();
        }
        if(currentIndex==world3Index){
            aud.clip=songs[3];
            aud.Play();
        }
    }
    
}
