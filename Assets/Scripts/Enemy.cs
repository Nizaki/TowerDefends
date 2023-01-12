using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public float hp = 10;
  public float speed = 10f;
  private int waypointIndex = 0;
  private Transform target;
  public Type type = Type.A;
  private bool slowed = false;
  // Start is calle d before the first frame update
  void Start()
  {
    target = Waypoint.points[0];
    hp = hp * (1 + (WaveSpawner.Round * 0.005f));
    speed = speed * (1 + (WaveSpawner.Round * 0.005f));
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 dir = target.position - transform.position;
    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    if (Vector2.Distance(transform.position, target.position) <= 0.2f)
    {
      NextWaypoint();
    }
  }

  public void Slow()
  {
    if (slowed) return;
    speed = speed * 0.7f;
    slowed = true;
  }

  public void Hit(float damage, Type DamageType)
  {
    hp -= DamageType == type ? damage * 1.5f : damage;
    if (hp <= 0)
    {
      Destroy(gameObject);
    }
  }

  void NextWaypoint()
  {
    if (waypointIndex >= Waypoint.points.Count - 1)
    {
      Destroy(gameObject);
      return;
    }
    target = Waypoint.points[++waypointIndex];
  }
}
