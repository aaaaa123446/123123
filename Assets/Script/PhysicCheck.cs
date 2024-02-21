using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicCheck : MonoBehaviour
{
    public float radius;
    public Vector3 leftCheckOffect;
    public Vector3 rightCheckOffect;
    public Vector3 upCheckOffect;
    public Vector3 downCheckOffect;
    public LayerMask wall;
    public bool onLeftWall;
    public bool onRightWall;
    public bool onUpWall;
    public bool onDownWall;
    private void Update()
    {
        Check();
        
    }
    private void Check()
    {
        onLeftWall=Physics2D.OverlapCircle(transform.position+ leftCheckOffect, radius,wall);
        onRightWall=Physics2D.OverlapCircle(transform.position + rightCheckOffect, radius, wall);
        onUpWall=Physics2D.OverlapCircle(transform.position + upCheckOffect, radius, wall);
        onDownWall=Physics2D.OverlapCircle(transform.position + downCheckOffect, radius, wall);
  
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position+ leftCheckOffect, radius);
        Gizmos.DrawWireSphere(transform.position + rightCheckOffect, radius);
        Gizmos.DrawWireSphere(transform.position + upCheckOffect, radius);
        Gizmos.DrawWireSphere(transform.position + downCheckOffect, radius);
    }
}
