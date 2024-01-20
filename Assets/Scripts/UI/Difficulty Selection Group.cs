using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelectionGroup : ButtonManager
{
    [Header("Difficulty Selection")]
    public bool _isShowing;
    // Start is called before the first frame update
    void Start()
    {
        _isShowing = false;
    }
}
