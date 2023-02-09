using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //public GameObject[] lstPrefabRoad;

    //public Vector3 currentPosition;
    //public Quaternion currentRotation;

    public GameObject[] roadSegmentPrefabs;
    public int numberOfSegments = 10;
    public float segmentLength = 10.0f;

    public Vector3 currentPosition;
    public Quaternion currentRotation;

    void Start()
    {
        currentPosition = transform.position;
        currentRotation = transform.rotation;
        GenerateRoad();
    }

    void GenerateRoad()
    {
        for (int i = 0; i < numberOfSegments; i++)
        {
            int randomIndex = Random.Range(0, roadSegmentPrefabs.Length);
            GameObject segment = Instantiate(roadSegmentPrefabs[randomIndex], currentPosition, currentRotation);
            segment.transform.parent = transform;

            currentPosition = segment.transform.GetChild(0).position;
            currentRotation = segment.transform.GetChild(0).rotation;
        }
    }
}
