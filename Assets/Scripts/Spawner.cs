using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;

    private void Awake()
    {
        StartCoroutine(DelaySpawn());
    }

    private void Spawn()
    {
        var direction = (_target.position - transform.position).normalized;
        var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
        bullet.Init(direction);
    }

    private IEnumerator DelaySpawn()
    {
        bool isWork = enabled;

        while (isWork)
        {
            Spawn();
            yield return new WaitForSeconds(_delay);
        }
    }
}