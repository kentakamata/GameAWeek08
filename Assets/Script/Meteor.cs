using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int hp = 100;
    float fallSpeed;
    float minScale = 0.3f;

    void Start()
    {
        float scale = Random.Range(0.8f, 1.5f);
        transform.localScale = Vector3.one * scale;
        fallSpeed = Random.Range(1.5f, 3.5f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        float newScale = transform.localScale.x - 0.1f;
        newScale = Mathf.Max(newScale, minScale);
        transform.localScale = Vector3.one * newScale;

        if (hp <= 0)
            Destroy(gameObject);
    }

    // ƒvƒŒƒCƒ„[‚É“–‚½‚Á‚½‚Æ‚«
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddHit();
            Destroy(gameObject);
        }
    }
}
