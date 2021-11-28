using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StandartButtonCheckLies : MonoBehaviour
{
    public InputField InputСlarifyingInformation;
    [SerializeField] private int Score;
    [SerializeField] private string[] characteristic;

    public void CheckLies(){
        if(InputСlarifyingInformation.text == "" && Score > 0){
            if(Score == 3){
                Score=1;
            }else{
                Score=0;
            }
        }
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
