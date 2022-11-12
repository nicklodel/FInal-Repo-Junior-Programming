using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : Obstacle
{
    // Start is called before the first frame updat
    public ParticleSystem Explosion;
    public override void Jump()
    {
        if (isOnGround == true)
        {
            Rb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Explosion.Play();
        }
    }
    void Start()
    {
        base.Rb = gameObject.GetComponent<Rigidbody>();
        base.isOnGround = false;
        base.seconds = 5;
        base.m_jumpForce = 10;
    }

    // Update is called once per frame
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
        Jump(); //Abstraction
    }
    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}
