using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Collider2D _collider;

    [SerializeField]
    private Transform _transformStart;

    // Action < IsIdle, IsHurt >
    public Action<bool, bool> OnRespawnPlayer = delegate { };

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();

        GetComponent<PlayerHurt>().OnHurtEnd += Respawn;
    }

    private void Respawn()
    {
        StartCoroutine(CoroutineRespawn());
    }

    private IEnumerator CoroutineRespawn()
    {
        yield return new WaitForSeconds(0.75f);
        _collider.enabled = true;
        Vector3 position = _transformStart.position;
        transform.position = position;

        OnRespawnPlayer?.Invoke(true, false);
    }
}
