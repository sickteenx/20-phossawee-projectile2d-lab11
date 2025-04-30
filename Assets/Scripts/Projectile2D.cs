using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target;   
    [SerializeField] Rigidbody2D bulletPrefab; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f); 

            
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            
            if (hit.collider != null)
            {
                
                if (target != null)
                {
                    target.transform.position = new Vector2(hit.point.x, hit.point.y);
                }
                Debug.Log("hit " + hit.collider.name);
            }
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        //find velocity of x and y axis
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        //get projectile vector
        Vector2 projectileVelocity = new Vector2(velocityX, velocityY);

        return projectileVelocity;
    }
}