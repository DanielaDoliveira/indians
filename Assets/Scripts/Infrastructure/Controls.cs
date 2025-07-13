using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class Controls 
    {
        private int scene { get; set; }

        public Controls(int scene) => this.scene = scene;
    

        public void Play() => SceneManager.LoadScene(scene);
        public void Quit() => Application.Quit();
   
    }
}
