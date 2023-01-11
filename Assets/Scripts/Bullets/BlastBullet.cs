using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBullet : Bullet
{
  public GameObject hitEffect;
  public float explosiveRadius = 3f;
  public float minDamage = 8f;
  public override void Hit(Enemy target)
  {
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosiveRadius);
    foreach (Collider2D collider in colliders)
    {
      if (collider.tag == "Enemy")
      {
        var e = collider.GetComponent<Enemy>();
        var dist = Vector2.Distance(transform.position, collider.transform.position);

        if (e != null)
        {
          e.Hit(map(dist, 0, 5, minDamage, damage), type);
        }
      }
    }

  }

  void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, explosiveRadius);
  }

  float map(float x, float in_min, float in_max, float out_min, float out_max)
  {
    return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
  }
}
