using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSwim : MonoBehaviour
{
    [SerializeField] private Rigidbody2D fRigidBody;
    [SerializeField] private Animator fAnimator;
    private float fDestroyTime = 15.0f;
    private float fSpeed;
    // Start is called before the first frame update
    void Start()
    {
        fRigidBody =  this.GetComponent<Rigidbody2D>();
        fAnimator = this.GetComponent<Animator>();
        fSpeed = Random.Range(1.0f, 2.0f);
        fDestroyTime += 3/fSpeed * 2.0f;
        Destroy(this.gameObject, fDestroyTime - fSpeed);

        fRigidBody.velocity = (Vector2)transform.TransformDirection(Vector3.left) * fSpeed;
        fAnimator.speed = fSpeed / 2;
    }
}
