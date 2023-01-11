using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public Type type = Type.A;
  public float damage = 5f;
  public void Seek(Transform target)
  {
    Vector3 dir = target.transform.position - transform.position;
    float angle = Vector3.SignedAngle(transform.up, dir, transform.forward);
    transform.Rotate(0f, 0f, angle);
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.up.normalized * Time.deltaTime * 15);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log("hit");
    var comp = collision.GetComponent<Enemy>();
    if (comp != null)
    {
      Hit(comp);
      Destroy(gameObject);
    }
  }

  public virtual void Hit(Enemy target)
  {
    target.Hit(damage, type);
  }
}
