using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void MoveToScene(int aSceneID)
    {
        SceneManager.LoadScene(aSceneID);
    }
}
