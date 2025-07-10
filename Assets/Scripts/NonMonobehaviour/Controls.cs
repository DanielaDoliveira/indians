using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace  GuaresQuest.UI
{
    public class Controls 
    {
        private int scene { get; set; }

        public Controls(int scene) => this.scene = scene;
    

        public void Play() => SceneManager.LoadScene(scene);
        public void Quit() => Application.Quit();
   
    }
}
