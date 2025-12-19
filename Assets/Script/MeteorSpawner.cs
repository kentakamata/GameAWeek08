using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;

    void Update()
    {
        if (Random.Range(0, 100) < 2)
        {
            float x = Random.Range(-9f, 3f); // ¶2/3‚Ì‚Ý
            Instantiate(meteorPrefab, new Vector3(x, 6f, 0), Quaternion.identity);
        }
    }
}
