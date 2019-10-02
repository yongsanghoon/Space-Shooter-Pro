using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to wait 5 seconds per enemy spawn
    private IEnumerator SpawnRoutine()
    {
        // Use a infinite while loop
        while (!_stopSpawning)
        {
            // Instantiate enemy prefab
            Vector3 randomPos = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, randomPos, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;

            // yield for 5 seconds
            yield return new WaitForSeconds(5);
        }
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
