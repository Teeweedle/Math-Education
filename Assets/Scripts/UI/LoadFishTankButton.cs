using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFishTankButton : MonoBehaviour
{
    private const int _FISHTANKSCENE = 7;
    public void OnClick()
    {
        Scene lScene = SceneManager.GetSceneAt(1);
        if(lScene.buildIndex == 1)
        {
            LoadScene._instance.LoadSceneTransition(lScene.name, _FISHTANKSCENE);
        }        
    }
}
