using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESET : MonoBehaviour
{
    
    public void FuncButton(){
        PlayerPrefs.DeleteKey("currentSceneMilman");
        SceneManager.LoadScene(0);
    }
}
