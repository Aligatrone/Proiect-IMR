using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(XROrigin))]
public class RoomScaleFix : MonoBehaviour
{
    CharacterController character;

    XROrigin xrOrigin;

    void Start()
    {
        character = GetComponent<CharacterController>();
        xrOrigin = GetComponent<XROrigin>();
    }

    void FixedUpdate()
    {
        var centerPoint = transform.InverseTransformPoint(xrOrigin.Camera.transform.position);
        character.center = new Vector3(centerPoint.x, character.height / 2 + character.skinWidth, centerPoint.z);

        character.Move(new Vector3(0.001f, -0.001f, 0.001f));
        character.Move(new Vector3(-0.001f, -0.001f, -0.001f));
    }

}
