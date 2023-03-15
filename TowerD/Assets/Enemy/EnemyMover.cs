using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)]float speed = 1f;

    Enemy enemy;

    void OnEnable()
    {
      FindPath();
      ReturnToStart();
      StartCoroutine(FollowPath());
    }

    void Start()
    {
      enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
      path.Clear();

      GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

      foreach (GameObject waypoint in waypoints)
      {
        path.Add(waypoint.GetComponent<Waypoint>());
      }
    }

    void ReturnToStart()
    {
      transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
      foreach(Waypoint waypoint in path)
      {
        //transform.position = waypoint.transform.position;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = waypoint.transform.position;
        float travelPercent = 0f;

        transform.LookAt(endPosition);

        while (travelPercent < 1f) {
          travelPercent += Time.deltaTime * speed;
          transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
          yield return new WaitForEndOfFrame();
        }
        
        //yield return new WaitForSeconds(waitTime);
      }

      gameObject.SetActive(false);
      enemy.RemoveGold();
    }
}
