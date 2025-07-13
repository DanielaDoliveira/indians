using Domain;
using Infrastructure;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Presentation
{
    public class Indian : MonoBehaviour
    {
   
        private Animator _animator;
        private Rigidbody2D _rb;
     
        [Required] [FoldoutGroup("Referências", expanded: true)]
        public GameObject GameOverPanel;

        [FoldoutGroup("Referências")]
        [SerializeField] private Transform groundCheck;

        [FoldoutGroup("Configurações de Pulo", expanded: true)]
        [SerializeField] private float jumpForce = 5f;

        [FoldoutGroup("Detecção de Chão", expanded: true)]
        [SerializeField] private float groundCheckRadius = 0.2f;

        [FoldoutGroup("Detecção de Chão")]
        [SerializeField] private LayerMask groundLayer;

        [FoldoutGroup("Configuração de Plataforma", expanded: true)]
        [SerializeField] private PlatformType platform;

        private PlayerControl _playerControl;
        private PlayerLife  _playerLife;
        private bool _isGrounded;
        private Vector2 _touchStartPos;
        private Vector2 _touchEndPos;
        private float swipeThreshold = 50f;
        private SoundFX _soundFX;
        private AudioSource source;
        [BoxGroup("Audio Clips")] [Required]
        public AudioClip jump;
  
 
        void Start()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
            source = GetComponent<AudioSource>();
            _soundFX = new SoundFX(source,jump);
            _playerControl = new PlayerControl(
                _animator, 
                _rb, 
                jumpForce, 
                groundCheck, 
                groundCheckRadius, 
                groundLayer,
                _touchStartPos, 
                _touchEndPos, 
                swipeThreshold,
                _soundFX
            );
            _playerLife = new PlayerLife(
                _animator,
                GetComponent<Collider2D>(),
                GameOverPanel,
                _rb);
            GameOverPanel.SetActive(false);
        }
    

        void PlatformSelected(PlatformType platform)
        {
            if (platform == PlatformType.desktop)  _playerControl.MouseAndKeyboard();
            else if (platform == PlatformType.mobile)  _playerControl.Swipe();
        }
    
        void Update()
        {
      
            PlatformSelected(platform);
     
            _animator.SetBool("isGrounded", _playerControl.IsGrounded());
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Management.Instance.SetUpFinishGame();
                _playerLife.Dead();
            }
        }

        public void OnDeath() => _playerLife.DeathLogic();


    }
}
    