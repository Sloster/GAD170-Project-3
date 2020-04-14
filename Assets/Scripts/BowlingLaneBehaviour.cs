using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple bowling lane logic, is triggered externally by buttons that are routed
/// to the InitialiseRound, TalleyScore and ResetRack.
/// 
/// Future work;
///   Use the timer in update to limit how long a player has to bowl,
///   Detect that the player/ball is 'bowled' from behind the line
/// </summary>
public class BowlingLaneBehaviour : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject bowlingBall;
    public Transform[] pinSpawnLocations;
    public Transform defaultBallLocation;
    
    List<GameObject> pins = new List<GameObject>();

    [ContextMenu("InitialiseRound")]
    public void InitialiseRound()
    {
        foreach (var pinLoc in pinSpawnLocations)
        {
            var newPin = Instantiate(pinPrefab, pinLoc.position, pinLoc.rotation);
            pins.Add(newPin);
        }
    }

    public void BallReachedEnd()
    {
        //bowlingBall.transform.position = defaultBallLocation.transform.position
    }

    int score;

    [ContextMenu("TalleyScore")]
    public void TalleyScore()
    {
        score = 0;

        for (int i = 0; i < pins.Count; i++)
        {
            float angle = Vector3.Dot(Vector3.up, pins[i].transform.up);

            if (angle <= 0.9f)
            {
                score++;
            }
        }

        print(score);
    }

    [ContextMenu("ResetRack")]
    public void ResetRack()
    {
        for (int i = 0; i < pins.Count; i++)
        {
            pins[i].transform.position = pinSpawnLocations[i].transform.position;
            pins[i].transform.rotation = pinSpawnLocations[i].transform.rotation;
        }

    bowlingBall.transform.position = defaultBallLocation.transform.position;
    bowlingBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
    bowlingBall.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    protected void Update()
    {

    }
}
