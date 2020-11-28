using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPoints : MonoBehaviour
{
    [Range(0, 1)]
    public float speed;

    [Range(0, 2)]
    public float alphaSpeed;

    public SpriteRenderer spriteRenderer0;
    public SpriteRenderer spriteRenderer1;
    private int points = 12;
    public void SetPoints(int _points)
    {
        print("_points " + _points);
        this.points = _points;
        print("points " + points);
        if (points >= 10)
        {
            spriteRenderer0.sprite = Resources.Load<Sprite>("Digitos/hud" + points.ToString().Substring(0, 1));
            spriteRenderer1.sprite = Resources.Load<Sprite>("Digitos/hud" + points.ToString().Substring(1, 1));
        }
        else
        {
            spriteRenderer1.sprite = Resources.Load<Sprite>("Digitos/hud" + points.ToString().Substring(0, 1));
        }
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Color nc = spriteRenderer1.color;
        nc.a = nc.a - alphaSpeed * Time.deltaTime;
        spriteRenderer1.color = nc;
        if (spriteRenderer0 != null)
        {
            spriteRenderer0.color = nc;
        }
        //Cuando desaparez el numero se destruye
        if (nc.a <= 0) Destroy(gameObject);
    }
}
