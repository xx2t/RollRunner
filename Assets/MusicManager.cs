using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public List<string> url;

    AudioClip currentClip;
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
    AudioSource aud;
    void Start(){
        aud=this.GetComponent<AudioSource>();
        aud.Play();
        StartCoroutine(StartNextLevel());
    }
    public IEnumerator StartNextLevel(){
        yield return new WaitForSeconds(0.5f);
        int currentIndex= SceneManager.GetActiveScene().buildIndex;
        if(currentIndex==mainMenuIndex){
            using (WWW www = new WWW(url[0])){
                yield return www;
                currentClip=www.GetAudioClip();
            }
            aud.PlayOneShot(currentClip);
        }
        if(currentIndex==world1Index){
            using (WWW www = new WWW(url[1])){
                yield return www;
                currentClip=www.GetAudioClip();
            }
            aud.PlayOneShot(currentClip);
        }
        if(currentIndex==world2Index){
            using (WWW www = new WWW(url[2])){
                yield return www;
                currentClip=www.GetAudioClip();
            }
            aud.PlayOneShot(currentClip);
        }
        if(currentIndex==world3Index){
            using (WWW www = new WWW(url[3])){
                yield return www;
                currentClip=www.GetAudioClip();
            }
            aud.PlayOneShot(currentClip);
        }
    }
}
