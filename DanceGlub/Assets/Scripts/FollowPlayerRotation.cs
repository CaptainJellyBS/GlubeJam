using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerRotation : MonoBehaviour
{
    public bool following = true;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(following)
        {
            transform.rotation = player.transform.rotation;
        }
    }
}
