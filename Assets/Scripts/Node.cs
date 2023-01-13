using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
  public Turret currentTarget;
  public void Build(GameObject turret)
  {
    if (currentTarget != null) { return; }
    var go = Instantiate(turret, transform);
    var comp = go.GetComponent<Turret>();
    currentTarget = comp;

  }

  private void OnMouseDown()
  {
    if (EventSystem.current.IsPointerOverGameObject() || currentTarget != null) return;
    BuildPanel.instance.Open(this);
  }
}
