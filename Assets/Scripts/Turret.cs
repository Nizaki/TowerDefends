using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{

  List<GameObject> EnemyInRange = new();
  GameObject target;
  public string ennemyTag = "Enemy";
  public float range = 10f;
  public float fireRate = 1f;
  public float fireCountdown = 0f;
  public GameObject bulletPrefab;
  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating(nameof(CheckNearestEnemy), 0, 0.5f);
  }

  void Update()
  {
    if (target == null)
      return;

    Vector3 dir = target.transform.position - transform.position;
    float angle = Vector3.SignedAngle(transform.up, dir, transform.forward);
    transform.Rotate(0f, 0f, angle);

    if (fireCountdown <= 0f)
    {
      Shoot();
      fireCountdown = fireRate;
    }

    fireCountdown -= Time.deltaTime;
  }

  void Shoot()
  {
    var bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);
    var component = bulletObj.GetComponent<Bullet>();
    component.Seek(target.transform);
  }

  void CheckNearestEnemy()
  {
    List<GameObject> enemies = GameObject.FindGameObjectsWithTag(ennemyTag).ToList();
    float shortestDis = Mathf.Infinity;
    GameObject nearEnemy = null;
    enemies.ForEach((e) =>
    {
      float dist = Vector3.Distance(transform.position, e.transform.position);
      if (dist < shortestDis)
      {
        shortestDis = dist;
        nearEnemy = e;
      }
    });

    if (nearEnemy != null && shortestDis <= range)
    {
      target = nearEnemy;
    }
    else
    {
      target = null;
    }
  }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, 1 + range);
  }
}
