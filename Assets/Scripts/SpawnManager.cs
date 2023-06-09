using System.Collections;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int _roundNum = 1;
    private float _range = 9;
    private int _enemyCount = 0;

    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _powerUp;
    [SerializeField]
    private GameObject _scores;
    [SerializeField]
    private GameObject _finish;
    [SerializeField]
    private TMP_Text _text;

    void Start()
    {
        Instantiate(_powerUp, _powerUp.transform.position, _powerUp.transform.rotation);
        StartCoroutine(Round(_roundNum));
        Spawner(_roundNum);
    }

    void Update()
    {
        _enemyCount = FindObjectsOfType<Enemy>().Length;
        if (_enemyCount == 0)
        {
            _roundNum++;
            StartCoroutine(Round(_roundNum));
            Spawner(_roundNum);
        }

    }

    private void Spawner(int number)
    {
        for (int i = 0; i < number; i++)
        {
            float spawnX = UnityEngine.Random.Range(-_range, _range);
            float spawnZ = UnityEngine.Random.Range(-_range, _range);
            Instantiate(_enemy, new Vector3(spawnX, 0, spawnZ), _enemy.transform.rotation);
            Instantiate(_powerUp, _powerUp.transform.position, _powerUp.transform.rotation);
        }
    }

    IEnumerator Round(int i)
    {
        _text.text = i.ToString();
        _scores.SetActive(true);
        yield return new WaitForSeconds(1);
        _scores.SetActive(false);
    }
}

