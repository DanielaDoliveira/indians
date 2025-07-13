using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speed;
    protected EnemyType type;

    public virtual void Initialize(EnemyData data)
    {
        speed = data.speed;
        type = data.type;
    }

    protected virtual void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (!IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject);
        }
    }

    private bool IsVisibleFrom(Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Renderer>().bounds);
    }

   
}
