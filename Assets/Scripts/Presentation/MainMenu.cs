using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using Infrastructure;

namespace GuaresQuest.UI
{
    public class MainMenu : MonoBehaviour
    {
        
        
        private Controls _controls;
        private int _nextScene;
        [SerializeField] private Button play;
       [SerializeField]private float animationDuration;
        void Start()
        {
            _nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            animationDuration = 0.3f;
            _controls = new Controls(_nextScene);
            play.onClick.AddListener(OnPlay);
            
        }

        void OnPlay()
        {
            
            play.interactable = false;
            play.transform.DOScale(0.8f, 0.1f).SetEase(Ease.InQuad).OnComplete(() =>
            {
                play.transform.DOScale(1f, animationDuration).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    DOVirtual.DelayedCall(0.3f, () => {
                        _controls.Play();
                    });
                });
            });
            
        }

    }

}