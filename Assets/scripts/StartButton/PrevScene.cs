using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrevScene : MonoBehaviour
{
    public int prevScene;
    
    public void FuncButton(){
        SceneManager.LoadScene(prevScene);
    }
}
