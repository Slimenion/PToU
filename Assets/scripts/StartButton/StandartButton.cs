using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StandartButton : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private string[] characteristic;

    public void FuncButton(){
        for(int j = 0; j<characteristic.Length; j++){
            if(PlayerPrefs.HasKey(characteristic[j])){
                int i =  PlayerPrefs.GetInt(characteristic[j]);
                i+=Score;
                PlayerPrefs.SetInt(characteristic[j], i);
            }else{
                PlayerPrefs.SetInt(characteristic[j], Score);
            }
        }
        int currentScene = PlayerPrefs.GetInt("currentSceneMilman") + 1;
        PlayerPrefs.SetInt("currentSceneMilman",currentScene);
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentSceneMilman"));
    }
}
