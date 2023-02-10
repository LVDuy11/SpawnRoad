using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> roadSegmentPrefabs;
    public GameObject roadSegmentPrefabs1;
    public GameObject roadUp;
    public GameObject roadDown;
    public GameObject roadEnd;
    public int numberOfSegments = 2;
    public float segmentLength = 10.0f;
    public bool checkTurn=false;
    public int indexRoad=0;

    public Vector3 currentPosition;
    public Quaternion currentRotation;


    void Start()
    {
        roadSegmentPrefabs1=Instantiate(roadSegmentPrefabs[0], transform.position, transform.rotation);
        roadSegmentPrefabs1.SetActive(true);
        currentPosition = roadSegmentPrefabs1.transform.GetChild(0).position;
        currentRotation = roadSegmentPrefabs1.transform.rotation;
        GenerateRoad();
    }

    void GenerateRoad()
    {
        this.SpawnRoad_1();

        roadSegmentPrefabs.RemoveAt(1);
        roadSegmentPrefabs.RemoveAt(1);
        roadSegmentPrefabs.Add(roadUp);
        roadSegmentPrefabs.Add(roadDown);

        for (int i = 0; i < numberOfSegments; i++)
        {

            int randomIndex = Random.Range(0, roadSegmentPrefabs.Count);
            if (randomIndex == 1)
            {
                Vector3 pos = new(-7.5f, 0, 15f);
                currentPosition += pos;
                GameObject segment = Instantiate(roadSegmentPrefabs[randomIndex], currentPosition, roadSegmentPrefabs[randomIndex].transform.rotation);
                segment.SetActive(true);
                currentPosition = segment.transform.GetChild(0).position;
                currentRotation = Quaternion.Euler(0f, 90f, 0f);
                this.checkTurn = true;
                indexRoad++;
                break;
            }
            if (randomIndex == 2)
            {
                Vector3 pos = new(7.5f, 0, 15f);
                currentPosition += pos;
                GameObject segment = Instantiate(roadSegmentPrefabs[randomIndex], currentPosition, roadSegmentPrefabs[randomIndex].transform.rotation);
                segment.SetActive(true);
                currentPosition = segment.transform.GetChild(0).position;
                currentRotation = segment.transform.rotation;
                this.checkTurn = false;
                indexRoad++;
                break;
            }
            else
            {
                if (checkTurn)
                {
                    for (int j = 0; j < numberOfSegments - indexRoad; j++)
                    {
                        Vector3 pos = new(-15, 0, 0);
                        currentPosition += pos;
                        this.SpawnRoad(1, roadSegmentPrefabs[0]);
                    }
                }

                else
                {
                    for (int j = 0; j < numberOfSegments - indexRoad; j++)
                    {
                        Vector3 pos = new(15, 0, 0);
                        currentPosition += pos;
                        this.SpawnRoad(1, roadSegmentPrefabs[0]);
                    }
                }
            }
        }

        currentRotation = Quaternion.Euler(0, 0, 0);
        if (checkTurn)
        {
            for (int i = 0; i < numberOfSegments - indexRoad; i++)
            {
                Vector3 pos = new(-15, 0, 0);
                currentPosition += pos;
                this.SpawnRoad(1, roadSegmentPrefabs[0]);
            }
        }

        else
        {
            for (int i = 0; i < numberOfSegments - indexRoad; i++)
            {
                Vector3 pos = new(15, 0, 0);
                currentPosition += pos;
                this.SpawnRoad(1, roadSegmentPrefabs[0]);
            }
        }

        float pos_x_end;
        if (currentPosition.x > 0)
        {
            pos_x_end = 7.5f;
        }
        else pos_x_end = -7.5f;

        Vector3 posEnd = new(pos_x_end, 0, 0);
        currentPosition += posEnd;
        GameObject finish = Instantiate(roadEnd, currentPosition, currentRotation);
        finish.SetActive(true);
    }

    protected virtual void SpawnRoad(int x, GameObject a)
    {
        GameObject segment = Instantiate(a, currentPosition, currentRotation);
        segment.SetActive(true);
        currentPosition = segment.transform.GetChild(x).position;
        currentRotation = segment.transform.rotation;
    }

    protected virtual void SpawnRoad_1()
    {
        for (int i = 0; i < numberOfSegments; i++)
        {

            int randomIndex = Random.Range(0, roadSegmentPrefabs.Count);
            if (randomIndex == 1)
            {
                Vector3 pos = new(-7.5f, 0, 15f);
                currentPosition += pos;
                GameObject segment = Instantiate(roadSegmentPrefabs[randomIndex], currentPosition, currentRotation);
                segment.SetActive(true);
                currentPosition = segment.transform.GetChild(0).position;
                currentRotation = Quaternion.Euler(0f, 90f, 0f);
                this.checkTurn = true;
                indexRoad++;
                break;
            }
            if (randomIndex == 2)
            {
                Vector3 pos = new(7.5f, 0, 15f);
                currentPosition += pos;
                GameObject segment = Instantiate(roadSegmentPrefabs[randomIndex], currentPosition, roadSegmentPrefabs[randomIndex].transform.rotation);
                segment.SetActive(true);
                currentPosition = segment.transform.GetChild(0).position;
                currentRotation = segment.transform.rotation;
                this.checkTurn = false;
                indexRoad++;
                break;
            }
            else
            {
                Vector3 pos = new(0, 0, 15f);
                currentPosition += pos;
                this.SpawnRoad(0, roadSegmentPrefabs[randomIndex]);
                indexRoad++;
            }
        }
    }
}
