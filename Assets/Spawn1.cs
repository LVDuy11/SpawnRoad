using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject[] roadSegments; // array of road segment prefabs
    public GameObject leftMarker; // left marker prefab
    public GameObject rightMarker; // right marker prefab

    private Vector3 currentPos; // current position of the last segment
    private Quaternion currentRot; // current rotation of the last segment

    void Start()
    {
        // initialize the starting position and rotation
        currentPos = Vector3.zero;
        currentRot = Quaternion.identity;

        // loop through each road segment
        for (int i = 0; i < roadSegments.Length; i++)
        {
            // instantiate the segment
            GameObject segment = Instantiate(roadSegments[i], currentPos, currentRot, transform);

            // calculate the next position and rotation based on the segment type
            if (segment.name == "StraightLine")
            {
                currentPos += currentRot * Vector3.forward * segment.transform.lossyScale.z;
            }
            else if (segment.name == "LeftTurn")
            {
                currentRot *= Quaternion.Euler(0, -90, 0);
                currentPos += currentRot * Vector3.forward * segment.transform.lossyScale.x;
            }
            else if (segment.name == "RightTurn")
            {
                currentRot *= Quaternion.Euler(0, 90, 0);
                currentPos += currentRot * Vector3.forward * segment.transform.lossyScale.x;
            }

            // instantiate the markers
            Instantiate(leftMarker, currentPos, currentRot, segment.transform);
            currentPos += currentRot * Vector3.forward * segment.transform.lossyScale.z;
            Instantiate(rightMarker, currentPos, currentRot, segment.transform);
        }
    }
}
