using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    public  Transform       enemie;
    public  Transform[]     Position;
    private SpriteRenderer  beeSprite;
    private int             IdTarget;
    public  bool            facingRight;
    public  bool            shouldFlip;
    private float           speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(enemie != null){
            enemie.position = Vector3.MoveTowards(enemie.position, Position[IdTarget].position, speed * Time.deltaTime);

            if(enemie.position == Position[IdTarget].position){
                IdTarget +=1;
                if(IdTarget == Position.Length){
                    IdTarget = 0;
                }
            if(Position[IdTarget].position.x < enemie.position.x && facingRight && shouldFlip|| Position[IdTarget].position.x > enemie.position.x && !facingRight && shouldFlip){
                Flip();
            }
            }

        }
    }
    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
