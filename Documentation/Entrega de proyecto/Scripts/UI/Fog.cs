using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public float speed;
    public Transform startTransform;
    public Transform endTransform;
    RectTransform rt;
    void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.position = new Vector2(startTransform.position.x, startTransform.position.y);
    }

    void Update()
    {
        rt.Translate(Vector2.right * Time.deltaTime * speed);
        if (rt.position.x > endTransform.position.x)
        {
            rt.position = new Vector2(startTransform.position.x, startTransform.position.y);
        }
    }
}
