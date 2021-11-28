using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ClipboardExtension
{

    public static void CopyToClipboard(this string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }
}

public class CopyButton : MonoBehaviour
{
    public Text Code;
    public GameObject CopyText;

    public void CopyCode(){
        Code.text.CopyToClipboard();
        CopyText.SetActive(true);
    }
}
