using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float jumpForce = 4.0f;

    public float m_jumpForce
    {
        get { return jumpForce; }

        set //ENCAPSULATION
        {
            if (m_jumpForce > 0)
            {
                jumpForce = m_jumpForce;
            }
            else
            {
                Debug.LogError("No es posible realizar la modificación");
            }
        }
    }
    protected bool isOnGround;
    protected Rigidbody Rb;
    protected int seconds = 3;

    // Start is called before the first frame update
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody>();
        isOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround == true)
        {
            StartCoroutine(JumpEachTime());
        }
    
}

    public virtual void Jump()
    {
        if (isOnGround == true)
        {
            Rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
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
