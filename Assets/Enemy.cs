using System;
using UnityEngine;

public class Enemy : Characters
{
    public Transform[] waypoints;
    public int targetWaypoint;
    public float speed = 3;
    [SerializeField] private Player _player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == waypoints[targetWaypoint].position)
        {
            IncreaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetWaypoint].position, Time.deltaTime * speed);
        if (_player.win)
        {
            Destroy(this.gameObject);
        }
    }

    private void IncreaseTargetInt()
    {
        targetWaypoint++;
        if (targetWaypoint >= waypoints.Length)
        {
            targetWaypoint = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            if (_player.stealth)
            {
                
            }
            else
            {
                _player.checkDead = true;   
            }
        }
    }
}