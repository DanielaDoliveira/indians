using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX
{
     private AudioSource source {get; set;}
   
     private AudioClip jump {get; set;}

     public SoundFX(AudioSource source,  AudioClip jump)
     {
          this.source = source;
      
          this.jump = jump;
     }

  
     public void PlayJump() => source.PlayOneShot(jump);
}
