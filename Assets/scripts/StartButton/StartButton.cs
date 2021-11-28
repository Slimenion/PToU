using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public InputField InputFullName;
    public InputField InputGender;
    public InputField InputFaculty;
    public InputField InputClass;
    public InputField InputSubClass;
    public GameObject ErrorText;

    void Start(){
        if(PlayerPrefs.HasKey("currentSceneMilman")){
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentSceneMilman"));
        }
    }

    public void FuncButton(){
        if(InputFullName.text == ""|| InputGender.text == "" ||  InputFaculty.text == "" || InputClass.text == "" || InputSubClass.text == ""){
            ErrorText.SetActive(true);
        }else{
            PlayerPrefs.SetString("FullName", InputFullName.text);
            PlayerPrefs.SetString("Gender", InputGender.text);
            PlayerPrefs.SetString("Faculty", InputFaculty.text);
            PlayerPrefs.SetString("Class", InputClass.text);
            PlayerPrefs.SetString("SubClass", InputSubClass.text);
            //------------------------------- Обнуление/Инициализация Характеристик типа ОжИд
            PlayerPrefs.SetInt("POGID",0);
            PlayerPrefs.SetInt("OOGID",0);
            PlayerPrefs.SetInt("DOGID",0);
            PlayerPrefs.SetInt("ODOGID",0);
            PlayerPrefs.SetInt("COGID",0);
            PlayerPrefs.SetInt("DROGID",0);
            PlayerPrefs.SetInt("KOGID",0);
            //------------------------------- Обнуление/Инициализация Характеристик типа РбИд
            PlayerPrefs.SetInt("PRBID",0);
            PlayerPrefs.SetInt("ORBID",0);
            PlayerPrefs.SetInt("DRBID",0);
            PlayerPrefs.SetInt("ODRBID",0);
            PlayerPrefs.SetInt("CRBID",0);
            PlayerPrefs.SetInt("DRRBID",0);
            PlayerPrefs.SetInt("KRBID",0);
            //------------------------------- Обнуление/Инициализация Характеристик типа ОжРе
            PlayerPrefs.SetInt("POGRE",0);
            PlayerPrefs.SetInt("OOGRE",0);
            PlayerPrefs.SetInt("DOGRE",0);
            PlayerPrefs.SetInt("ODOGRE",0);
            PlayerPrefs.SetInt("COGRE",0);
            PlayerPrefs.SetInt("DROGRE",0);
            PlayerPrefs.SetInt("KOGRE",0);
            //------------------------------- Обнуление/Инициализация Характеристик типа РбРе
            PlayerPrefs.SetInt("PRBRE",0);
            PlayerPrefs.SetInt("ORBRE",0);
            PlayerPrefs.SetInt("DRBRE",0);
            PlayerPrefs.SetInt("ODRBRE",0);
            PlayerPrefs.SetInt("CRBRE",0);
            PlayerPrefs.SetInt("DRRBRE",0);
            PlayerPrefs.SetInt("KRBRE",0);
            //--------------------------------Обнуление Инициализация Характеристик ЭСТ
            PlayerPrefs.SetInt("EAST",0);
            PlayerPrefs.SetInt("EST",0);
            PlayerPrefs.SetInt("FAST",0);
            PlayerPrefs.SetInt("FST",0);
            //---------------------------------Установка текущей сцены
            PlayerPrefs.SetInt("currentSceneMilman",0);
            int currentScene = PlayerPrefs.GetInt("currentSceneMilman") + 1;
            PlayerPrefs.SetInt("currentSceneMilman",currentScene);
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentSceneMilman"));
            
        }
    }
}
