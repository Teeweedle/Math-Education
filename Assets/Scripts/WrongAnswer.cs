using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D fRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        float lX = Random.Range(-100, 100), lY = Random.Range(100, 300);
        fRigidBody.AddRelativeForce(new Vector2(lX, lY));
        Destroy(this.gameObject, Random.Range(1, 2));
    }
}
