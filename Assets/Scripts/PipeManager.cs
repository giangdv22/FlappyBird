using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PipeManager Instance { get; private set; }

    [SerializeField] private GameObject pipe;
    [SerializeField] private float distanceBetweenPipe;

    private float spawnPipeTimer;
    private float spawnPipeTimerMax = 3.0f;
    private float minHeight = 3.5f;
    private float maxHeight = 6.7f;
    private float destroyPipeTimer = 10.0f;

    private void Update()
    {
        if(spawnPipeTimer > spawnPipeTimerMax)
        {
            SpawnPipe();
            spawnPipeTimer = 0.0f;
        }
        spawnPipeTimer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(distanceBetweenPipe, Random.Range(minHeight, maxHeight));
        GameObject _pipe = Instantiate(pipe, spawnPos, Quaternion.identity);
        Destroy(_pipe, destroyPipeTimer);
    }

}
