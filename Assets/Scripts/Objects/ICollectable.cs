using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable 
{
    int Point {  get; set; }
    public void OnCollect();
}
