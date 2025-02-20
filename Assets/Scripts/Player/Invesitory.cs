using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Invesitory : MonoBehaviour
{
    public static Invesitory Instance;

    public TextMeshProUGUI tmp;
    private int currentPoint = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        tmp.SetText(currentPoint.ToString());   
    }
    public void Collect(ICollectable collectable)
    {
        currentPoint += collectable.Point;
        tmp.SetText(currentPoint.ToString());
    }
}
