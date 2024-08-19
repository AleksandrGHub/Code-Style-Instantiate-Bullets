using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _force;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(Counter());
    }

    private void Spawn()
    {
        var direction = (_target.position - transform.position).normalized;
        var bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = direction * _force;
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