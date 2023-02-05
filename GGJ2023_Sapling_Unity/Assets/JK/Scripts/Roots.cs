using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roots : MonoBehaviour
{
    public bool canMove = false;

    public void MoveRoot(Vector2 targetLoction)
    {
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            //transform.position += ;
        }
    }
}
