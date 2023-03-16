using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailControal : MonoBehaviour
{
    public float EnimeSpeed = 5.0f;
    public Transform bottomcollision;
    public LayerMask groundlayer;
    private Rigidbody2D _rBody;
    public bool _Moveleft;

     private void Start()
    {
        _Moveleft = true;
    }


    private void Awake()
    {
        _rBody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        checkcollision();
        EnimeWalk();
    }

    private void EnimeWalk()
    {
        if (_Moveleft) {

            _rBody.velocity = new Vector2(-EnimeSpeed, _rBody.velocity.y);

            changedirection(3);

        }

        else
        {
            _rBody.velocity = new Vector2(EnimeSpeed, _rBody.velocity.y);
            changedirection(-3);
        }
        
    }

    private void changedirection(int direction)
    {

        Vector3 tempscale = transform.localScale;
        tempscale.x = direction;
        transform.localScale = tempscale;


    }

    private void checkcollision()
    {
        if (!Physics2D.Raycast(bottomcollision.position, Vector2.down, 0.5f, groundlayer))
        {
            Changedirection();
        }
        

    }


    private void Changedirection()
    {

        _Moveleft = !_Moveleft;

    }




}
