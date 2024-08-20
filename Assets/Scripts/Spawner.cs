using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;

    private void Awake()
    {
        StartCoroutine(Counter());
    }

    private void Spawn()
    {
        var direction = (_target.position - transform.position).normalized;
        var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
        bullet.Accelerate(direction);
    }

    private IEnumerator Counter()
    {
        int numberSpawners = 5;

        while (numberSpawners > 0)
        {
            Spawn();
            numberSpawners--;
            yield return new WaitForSeconds(_delay);
        }
    }
}