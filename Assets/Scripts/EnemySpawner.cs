using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private Vector3 pos;
    private bool update = true;
    [SerializeField] private int spawnScale;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            update = false;
            StartCoroutine(SpawnEnemy());
        }

    }

    IEnumerator SpawnEnemy()
    {
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector3 spawnLocation = new Vector3(Mathf.Sin(angle), -.05f, Mathf.Cos(angle));
        spawnLocation *= spawnScale;
        spawnLocation = spawnLocation + pos;
        GameObject clone = Instantiate(enemy, spawnLocation, new Quaternion());
        clone.transform.LookAt(transform);
        yield return new WaitForSeconds(5);
        update = true;
    }
}
