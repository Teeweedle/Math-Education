using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStoreButton : MonoBehaviour
{
    private const int _STORESCENE = 6;
    public void OnClick()
    {
        Scene lScene = SceneManager.GetSceneAt(1);

        if(lScene.buildIndex == 1)
        {
            LoadScene._instance.LoadSceneTransition(lScene.name, _STORESCENE);
        }
    }
}
