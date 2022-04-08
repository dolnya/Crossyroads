using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private bool canMove = true;
    private UnityAction onDie;
    private Vector3 startPos;
    //private Vector3 startScale;
    //private Quaternion startRot;
    [SerializeField] private Transform realPlayer;
    [SerializeField] private Transform deadScale;
    [SerializeField] private Transform deadScale2;
    

    public void InitPlayer()
    {
        
        startPos = transform.position;
  

        
    }





    public void MoveForward()
    {
        if (!canMove)
            return;

        canMove = false;
        transform.DORotate(new Vector3(0, 0, 0), .2f);
        transform.DOJump(transform.position + Vector3.right * 1.5f, 1f,
            1, .2f).OnComplete(() => canMove = true);
    }

    public void MoveBackward()
    {
        if (!canMove)
            return;

        canMove = false;
        transform.DORotate(new Vector3(0, -180f, 0), .2f);
        transform.DOJump(transform.position + Vector3.left * 1.5f, 1f, 
            1, .2f).OnComplete(() => canMove = true);
    }

    public void MoveLeft()
    {
        if (!canMove)
            return;

        canMove = false;
        transform.DORotate(new Vector3(0, -90f, 0), .2f);
        transform.DOJump(transform.position + Vector3.forward * 1.5f, 1f, 
            1, .2f).OnComplete(() => canMove = true);
    }

    public void MoveRight()
    {
        if (!canMove)
            return;

        canMove = false;
        transform.DORotate(new Vector3(0, 90f, 0), .2f);
        transform.DOJump(transform.position + Vector3.back * 1.5f, 1f, 
            1, .2f).OnComplete(() => canMove = true);
    }

    public void OnDieAddListener(UnityAction callback)
    {
        onDie = callback;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            onDie.Invoke();
        }
        else if(other.CompareTag("car"))
        {
            if (Math.Abs(transform.position.y - startPos.y) < 0.01f)
            {
                realPlayer.DOScale(deadScale.transform.localScale, .1f);
                realPlayer.DOMove(deadScale.transform.position, .1f);
            }
            else
            {
                realPlayer.DOScale(deadScale2.transform.localScale, .1f);
                realPlayer.SetParent(other.transform);
            }

            onDie.Invoke();
        }
    }
}
