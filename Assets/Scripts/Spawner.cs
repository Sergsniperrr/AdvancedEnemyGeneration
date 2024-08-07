using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab);

        enemy.transform.position = transform.position;
        enemy.SetTarget(_target);
    }
}
