using System.Collections;
using UnityEngine;


public class SpawnCoins : MonoBehaviour
{
    [Header("Object to spawn")]
    [SerializeField] private GameObject _coin;
    [Header("Spawn Range")]
    [SerializeField] private float _spawnRange;
    [Header("Delay in seconds")]
    [SerializeField] private float _seconds;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_seconds);
        
        while (true)
        {
            Vector3 position = transform.position + new Vector3((Random.Range(-_spawnRange, _spawnRange)), 0, 0);
            Instantiate(_coin, position, Quaternion.identity);
            yield return waitForSeconds;
        }
    }
}
