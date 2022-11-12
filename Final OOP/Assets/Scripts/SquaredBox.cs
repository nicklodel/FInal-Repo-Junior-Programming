using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquaredBox : Obstacle //Inheritance
{
    
    // Start is called before the first frame updat
    public override void Jump() //POLYMORPHISM
    {
        if (isOnGround == true)
        {
            Rb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            Rb.AddTorque(Vector3.forward * m_jumpForce,ForceMode.Impulse);
            isOnGround = false;
            
        }
    }
    void Start()
    {
        base.Rb = gameObject.GetComponent<Rigidbody>();
        base.isOnGround = false;
        base.seconds = 8;
        base.m_jumpForce = 20;
    }

    void Update()
    {
        if (isOnGround == true)
        {
            StartCoroutine(JumpEachTime());
        }
    
    }

   
    private IEnumerator JumpEachTime()
    {
        yield return new WaitForSeconds(seconds);
        Jump();
    }
    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}
