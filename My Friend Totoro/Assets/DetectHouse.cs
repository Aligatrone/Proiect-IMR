using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHouse : MonoBehaviour
{
    public delegate void InHouse();
    public static event InHouse EnteredHouse;


    public delegate void Outside();
    public static event Outside ExitedHouse;

    private bool inHouse = false;
    private void OnControllerColliderHit(ControllerColliderHit other)
    {

        if (!other.collider.isTrigger)
        {
            if (other.collider.CompareTag("House"))
            {
                if (!inHouse)
                {
                    inHouse = true;
                    if (EnteredHouse != null)
                    {
                        EnteredHouse();
                    }
                }
            }
            else
            if (other.collider.CompareTag("Ground"))
            {
                if (inHouse)
                {
                    inHouse = false;
                    if (ExitedHouse != null)
                    {
                        ExitedHouse();
                    }
                }
            }
        }
    }

    private void OnControllerColliderExit(ControllerColliderHit other)
    {
        if (other.collider.isTrigger)
        {
            if (other.collider.CompareTag("House"))
            {
                if (inHouse)
                {
                    inHouse = false;
                    if (ExitedHouse != null)
                    {
                        ExitedHouse();
                    }
                }
            }
        }

    }


}
