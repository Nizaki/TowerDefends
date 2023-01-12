using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
  public GameObject[] enemyPrefabs;
  public int count = 10;
  public float waveCooldown = 60f;
  public Transform spawnPoint;
  public float countdown = 0f;
  public static int Round = 0;
  [SerializeField]
  private TextMeshProUGUI timeLabel;
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

    timeLabel.text = Mathf.Clamp(countdown, 0, Mathf.Infinity).ToString("0");
  }

  public void Skip()
  {
    if (countdown <= 3f)
    {
      return;
    }
    countdown = 3;
  }

  IEnumerator SpawnWave()
  {
    Round++;
    for (int i = 0; i < count; i++)
    {
      Instantiate(enemyPrefabs[Random.Range(0, 3)], spawnPoint.position, spawnPoint.rotation);
      yield return new WaitForSeconds(1);
    }
  }
}
