using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _force=20;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Accelerate(Vector3 direction)
    {
        _rigidbody.velocity = direction * _force;
    }
}