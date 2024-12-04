using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float speedZ;
    [SerializeField] private GameObject[] moveTrigs;
    private bool[] canMove = new bool[4]{true, true, true, true};
    void FixedUpdate()
    {
        CheckPosForMove();
        MoveX();
        MoveZ();
    }
    private void MoveX(){
        float vect = Input.GetAxis("Horizontal");
        if ((vect < 0 && canMove[0]) || (vect > 0 && canMove[1])){
            transform.position += new Vector3(vect * speedX, 0, 0);
        }
    }
    private void MoveZ(){
        float vect = Input.GetAxis("Vertical");
        if ((vect < 0 && canMove[2]) || (vect > 0 && canMove[3])){
            transform.position += new Vector3(0, 0, vect * speedZ);
        }
    }
    private void CheckPosForMove(){
        if (transform.position.x < moveTrigs[0].transform.position.x){
            canMove[0] = false;
        } else {
            canMove[0] = true;
        }
        if (transform.position.x > moveTrigs[1].transform.position.x){
            canMove[1] = false;
        } else {
            canMove[1] = true;
        }
        if (transform.position.z < moveTrigs[2].transform.position.z){
            canMove[2] = false;
        } else {
            canMove[2] = true;
        }
        if (transform.position.z > moveTrigs[3].transform.position.z){
            canMove[3] = false;
        } else {
            canMove[3] = true;
        }
    }
}
