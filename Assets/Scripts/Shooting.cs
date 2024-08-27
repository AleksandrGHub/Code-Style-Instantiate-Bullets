using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;

    private void Awake()
    {
        StartCoroutine(Shoot());
    }

    private void Spawn()
    {
        var direction = (_target.position - transform.position).normalized;
        var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
        bullet.Init(direction);
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        var wait = new WaitForSeconds(_delay);

        while (isWork)
        {
            Spawn();
            yield return wait;
        }
    }
}