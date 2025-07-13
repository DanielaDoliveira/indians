using UnityEngine;

namespace Infrastructure
{
    public class PlayerControl
    {
        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody;
        private readonly float _jumpForce;
        private readonly Transform _groundCheck;
        private readonly float _groundCheckRadius;
        private readonly LayerMask _groundLayer;
   
        private float _lastJumpTime = -1f;
        private const float _jumpAnimCooldown = 0.1f;
        private Vector2 TouchStartPos {get; set;}
        private Vector2 TouchEndPos {get; set;}
        private float SwipeThreshold {get; set;}
 
        private SoundFX _soundFX {get; set;}
   
        public PlayerControl(
            Animator animator, 
            Rigidbody2D rigidbody, 
            float jumpForce, 
            Transform groundCheck, 
            float groundCheckRadius, 
            LayerMask groundLayer,
            Vector2 touchStartPos, 
            Vector2 touchEndPos, 
            float swipeThreshold, SoundFX soundFX)
        {
            _animator = animator;
            _rigidbody = rigidbody;
            _jumpForce = jumpForce;
            _groundCheck = groundCheck;
            _groundCheckRadius = groundCheckRadius;
            _groundLayer = groundLayer;
            TouchStartPos = touchStartPos;
            TouchEndPos = touchEndPos;
            SwipeThreshold = swipeThreshold;
            _soundFX = soundFX;
        
        }

        public void Jump()
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _soundFX.PlayJump();
            if (Time.time - _lastJumpTime > _jumpAnimCooldown)
            {
                _animator.ResetTrigger("Jump");
                _animator.SetTrigger("Jump");
                _lastJumpTime = Time.time;
            }
        }

        public void Slide()
        {
            _animator.ResetTrigger("slide");
            _animator.SetTrigger("slide");
        }

        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        }
    
        public void MouseAndKeyboard()
        {
            if ((Input.GetMouseButtonDown(0) && IsGrounded())) Jump();
            if (( Input.GetKeyDown(KeyCode.Space)) && IsGrounded())  Slide();
        }

   
    
        public void Swipe()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
    
                if (touch.phase == TouchPhase.Began)   TouchStartPos = touch.position;
            
                else if (touch.phase == TouchPhase.Ended)
                {
                    TouchEndPos = touch.position;
                    Vector2 swipeDelta = TouchEndPos - TouchStartPos;
    
                    if (Mathf.Abs(swipeDelta.y) > SwipeThreshold && IsGrounded())
                    {
                        if (swipeDelta.y > 0) Jump();
                        else if (swipeDelta.y < 0)  Slide();
                    }
                }
            }
        }
    }
}
