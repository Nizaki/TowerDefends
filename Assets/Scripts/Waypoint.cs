using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
  public static List<Transform> points = new();
  private void Awake()
  {
    foreach (Transform item in transform)
    {
      points.Add(item);
    }
  }
}
