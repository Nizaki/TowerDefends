using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public Type type = Type.A;
  public float damage = 5f;
  public Transform target;
  public bool slowed = false;
  public void Seek(Transform target)
  {
    this.target = target;
  }

  // Update is called once per frame
  void Update()
  {

    if (target == null)
    {
      Destroy(gameObject);
      return;
    }

    if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
    {
      HitTarget();
      Destroy(gameObject);
    }
    Vector3 dir = target.transform.position - transform.position;
    float angle = Vector3.SignedAngle(transform.up, dir, transform.forward);
    transform.Rotate(0f, 0f, angle);
    transform.Translate(Vector2.up.normalized * Time.deltaTime * 15);
  }

  public virtual void HitTarget()
  {
    Damage(target);
  }

  void Damage(Transform enemy)
  {
    Enemy e = enemy.GetComponent<Enemy>();

    if (e != null)
    {
      e.Hit(damage, type);
      if (slowed)
      {
        e.Slow();
      }
    }
  }
}
