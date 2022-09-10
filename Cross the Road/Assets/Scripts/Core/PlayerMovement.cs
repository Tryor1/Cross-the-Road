using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PlayerMovement : MonoBehaviour
    {
        private bool notJumping = true;
        public void MoveForward()
        {
            if (!notJumping)
                return;

            notJumping = false;
            transform.DORotate(new Vector3(0, 0, 0), .1f);
            transform.DOJump(transform.position += Vector3.right * 1.8f, 1.5f, 1, .1f).OnComplete(()=>notJumping=true);
        }
        public void MoveBack()
        {
            if (!notJumping)
                return;

            notJumping = false;
            transform.DORotate(new Vector3(0, -180f, 0), .1f);
            transform.DOJump(transform.position += Vector3.left * 1.8f, 1.5f, 1, .1f).OnComplete(() => notJumping = true);
        }
        public void MoveRight()
        {
            if (!notJumping)
                return;

            notJumping = false;
            transform.DORotate(new Vector3(0, 90, 0), .1f);
            transform.DOJump(transform.position += Vector3.back * 1.8f, 1.5f, 1, .1f).OnComplete(() => notJumping = true);
        }
        public void MoveLeft()
        {
            if (!notJumping)
                return;

            notJumping = false;
            transform.DORotate(new Vector3(0, -90, 0), .1f);
            transform.DOJump(transform.position += Vector3.forward * 1.8f, 1.5f, 1, .1f).OnComplete(() => notJumping = true);
        }
    } 
}
