using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardItemProperties : MonoBehaviour
{
    [SerializeField] private bool _isStatic;

    public bool _IsStatic { get => _isStatic; set => _isStatic = value; }
}
