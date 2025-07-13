using Domain;
using Infrastructure;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Presentation.Installers
{
    public class IndianInstaller: LifetimeScope
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D collider2d;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip jumpClip;
        [SerializeField] private PlatformType platform;

        [SerializeField] private float jumpForce = 5f;
        [SerializeField] private float groundCheckRadius = 0.2f;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float swipeThreshold = 50f;
        
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(platform);

            var soundFX = new SoundFX(audioSource, jumpClip);
            builder.RegisterInstance(soundFX);

            builder.RegisterInstance(gameOverPanel);

            builder.Register<PlayerControl>(Lifetime.Scoped)
                .WithParameter(animator)
                .WithParameter(rb)
                .WithParameter(jumpForce)
                .WithParameter(groundCheck)
                .WithParameter(groundCheckRadius)
                .WithParameter(groundLayer)
                .WithParameter(Vector2.zero) // ou use outro sistema de input se quiser
                .WithParameter(Vector2.zero)
                .WithParameter(swipeThreshold)
                .WithParameter(soundFX);

            builder.Register<PlayerLife>(Lifetime.Scoped)
                .WithParameter(animator)
                .WithParameter(collider2d)
                .WithParameter(gameOverPanel)
                .WithParameter(rb);
        }
    }
}