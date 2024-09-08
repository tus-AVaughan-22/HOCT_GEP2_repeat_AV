using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterSwap : MonoBehaviour
{
    public CinemachineVirtualCamera _camera;
    public Transform playerBruss;
    public Transform playerTurna;
    public BrussMovement brussScript;
    public TurnaMovement turnaScript;

    // Start is called before the first frame update
    void Start()
    {
        _camera.Follow = playerBruss;
        brussScript.brussIsActive = true;
        turnaScript.turnaIsActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraSwap();
    }

    public void CameraSwap()
    {
        if(brussScript.brussIsActive == true)
        {
            _camera.Follow = playerBruss;

        }

        if(turnaScript.turnaIsActive == true)
        {
            _camera.Follow = playerTurna;

        }

    }


}
