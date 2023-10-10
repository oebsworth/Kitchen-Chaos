using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float footstepTimer;
    [SerializeField] private float footstepTimerMax = 0.3f;
    

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;

            if (player.IsWalking())
            {
                float footstepVolume = 1f;
                SoundManager.Instance.PlayFootstepSound(player.transform.position, footstepVolume);
            }
        }
    }
}
