using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private float maxPlace;

    void Start()
    {
        var update = Observable.EveryUpdate()
                     .Select(x => transform.position.x)
                     .Where(x => Mathf.Abs(x) > maxPlace)
                     .Subscribe(x => Teleporter());
    }

    private void Teleporter()
    {
        transform.position = new Vector2(transform.position.x * (-0.8f), transform.position.y);
    }
}
