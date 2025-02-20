using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, ICollectable
{

    private CircleCollider2D circleCollider;
    private int point = 1;

    public int Point { get => point; set => point = value; }

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollect();
    }
    public void OnCollect()
    {
        SoundManager.Instance.PlayerSFX("Collected SFX");
        gameObject.SetActive(false);
        circleCollider.enabled = false;
        Invesitory.Instance.Collect(this);
    }
}
