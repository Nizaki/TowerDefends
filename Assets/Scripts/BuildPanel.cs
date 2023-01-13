using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPanel : MonoBehaviour
{
  public static BuildPanel instance;
  RectTransform rectTransform;
  Node target;
  public List<GameObject> turret = new();
  private void Awake()
  {
    BuildPanel.instance = this;
    rectTransform = GetComponent<RectTransform>();
    gameObject.SetActive(false);
  }


  public void Open(Node target)
  {
    gameObject.SetActive(true);
    rectTransform.position = Camera.main.WorldToScreenPoint(target.transform.position);
    this.target = target;
  }

  public void Build(int type)
  {
    if (type < turret.Count)
    {
      target.Build(turret[type]);
    }
    else
    {
      Debug.LogWarning("exceed");
    }
    gameObject.SetActive(false);
  }
}
