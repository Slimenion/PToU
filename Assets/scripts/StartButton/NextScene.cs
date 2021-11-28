using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
  public int nextScene;

    public void FuncButton(){
        SceneManager.LoadScene(nextScene);
    }
}
