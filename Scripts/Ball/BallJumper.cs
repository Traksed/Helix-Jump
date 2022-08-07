using Platforms;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent(out PlatformSegment platformSegment)) return;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
