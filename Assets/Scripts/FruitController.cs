using Constants;
using Events;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    [Header("Raise Events")]
    [SerializeField] private FruitControllerEventChannelSO _eventFruitDisappear;

    [SerializeField] private AudioSource _collectAudioSource;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private CircleCollider2D _collider;
    private static readonly int DisappearId = Animator.StringToHash("Disappear");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Tags.Ground))
        {
            Disappear();
        }
    }

    public void Disappear()
    {
        _collider.enabled = false;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        _animator.SetTrigger(DisappearId);
    }

    // ReSharper disable once UnusedMember.Global
    /// <summary>
    /// Callback when animation Disappear is done
    /// </summary>
    public void OnDisappear()
    {
        _eventFruitDisappear.RaiseEvent(this);
    }

    public void BeCollected()
    {
        _collectAudioSource.Play();
        Disappear();
    }

    public void Fall()
    {
        _collider.enabled = true;
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        _animator.ResetTrigger(DisappearId);
    }
}