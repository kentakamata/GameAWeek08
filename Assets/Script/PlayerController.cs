using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;

    public float shotInterval = 0.5f;
    float shotTimer;

    // 左2/3の移動制限
    public float minX = -9f;
    public float maxX = 3f;

    void Update()
    {
        Move();
        AutoShoot();
    }

    void Move()
    {
        float h = 0f;
        if (Input.GetKey(KeyCode.A)) h = -1f;
        if (Input.GetKey(KeyCode.D)) h = 1f;

        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, 0);
    }

    void AutoShoot()
    {
        shotTimer -= Time.deltaTime;
        if (shotTimer <= 0f)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            shotTimer = shotInterval;
        }
    }

    // 強化：連射速度アップ
    public void UpgradeFireRate()
    {
        shotInterval = Mathf.Max(0.1f, shotInterval - 0.05f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(minX, -5, 0), new Vector3(minX, 5, 0));
        Gizmos.DrawLine(new Vector3(maxX, -5, 0), new Vector3(maxX, 5, 0));
    }

}
