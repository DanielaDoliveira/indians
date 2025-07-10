using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class PlayerLife
{
   private Animator Animator{get;set;}
   private Collider2D Collider {get;set;}
   private GameObject GameOverPanel{get;set;}
   private Rigidbody2D Rigidbody2D{get;set;}
   public PlayerLife(Animator animator, Collider2D collider, GameObject gameOverPanel, Rigidbody2D rigidbody2D)
   {
       Animator = animator;
       Collider = collider;
       GameOverPanel = gameOverPanel;
       Rigidbody2D = rigidbody2D;
   }

   public void Dead()
   {
       Collider.enabled = false;
       Rigidbody2D.gravityScale = 0;
       Animator.Play("dead");
   }

   public void DeathLogic()
   {
      Time.timeScale = 0;
       GameOverPanel.SetActive(true);
   }

   
}
