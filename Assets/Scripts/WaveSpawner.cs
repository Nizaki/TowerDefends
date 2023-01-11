using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
  public GameObject[] enemyPrefabs;
  public float waveCooldown = 60f;
  public Transform spawnPoint;
  public float countdown = 0f;
  public static int Round = 0;
  // Start is called before the first frame update
  void Start()
  {
    countdown = waveCooldown;
  }

  // Update is called once per frame
  void Update()
  {
    if (countdown <= 0f)
    {
      StartCoroutine(SpawnWave());
      countdown = waveCooldown;
    }

    countdown -= Time.deltaTime;
  }

  IEnumerator SpawnWave()
  {
    Round++;
    for (int i = 0; i < 10; i++)
    {
      Instantiate(enemyPrefabs[Random.Range(0, 2)], spawnPoint.position, spawnPoint.rotation);
      yield return new WaitForSeconds(1);
    }
  }
}
