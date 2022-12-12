using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class ChangeScreenXCinemachine : MonoBehaviour
{
    [SerializeField]
    private PlayerFacingDirection playerFacingDirection;

    [SerializeField]
    private float minScreenX = 0.1f;
    [SerializeField]
    private float maxScreenX = 0.9f;

    [Space]

    [SerializeField]
    private float minBiasX = 0;
    [SerializeField]
    private float maxBiasX = 0.5f;

    private bool isMinScreenX = true;

    private void Awake()
    {
        playerFacingDirection.OnFlip += UpdateScreenX;
    }

    private void UpdateScreenX(bool isFacingRight)
    {
        if (!isMinScreenX && isFacingRight)
        {
            CinemachineFramingTransposer cinemachineFramingTransposer = GetComponent<CinemachineVirtualCamera>().
                                                                        GetCinemachineComponent<CinemachineFramingTransposer>();
            cinemachineFramingTransposer.m_ScreenX = minScreenX;
            cinemachineFramingTransposer.m_BiasX = maxBiasX;
            isMinScreenX = true;
        }else if(isMinScreenX && !isFacingRight)
        {
            CinemachineFramingTransposer cinemachineFramingTransposer = GetComponent<CinemachineVirtualCamera>().
                                                                        GetCinemachineComponent<CinemachineFramingTransposer>();
            cinemachineFramingTransposer.m_ScreenX = maxScreenX;
            cinemachineFramingTransposer.m_BiasX = minBiasX;
            isMinScreenX = false;
        }
    }


}
