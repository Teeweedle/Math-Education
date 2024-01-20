using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBG : MonoBehaviour
{
    [SerializeField] private Camera fMainCamera;
    [SerializeField] private SpriteRenderer fBGSprite;
    private bool fIsAspectRatio;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 lTopRightCorner = fMainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, fMainCamera.transform.position.z));
        //float lWorldSpaceWidth = lTopRightCorner.x * 2;
        //float lWorldSpaceHeight = lTopRightCorner.y * 2;

        //float lScalefactorX = lWorldSpaceWidth / fBGSprite.size.x;
        //float lScaleFactorY = lWorldSpaceHeight / fBGSprite.size.y;

        //if (fIsAspectRatio)
        //{
        //    if (lScalefactorX > lScaleFactorY)
        //        lScaleFactorY = lScalefactorX;
        //    else
        //        lScaleFactorY = lScalefactorX;
        //}

        //transform.localScale = new Vector3(lScalefactorX, lScaleFactorY, 1);



    }    
}
