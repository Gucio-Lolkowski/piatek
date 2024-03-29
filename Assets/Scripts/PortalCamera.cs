using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    void Update()
    {

        PortalCameraCaculation();
    }

    void PortalCameraCaculation()
    {
        Vector3 distanceBetweenPortalPlayer = playerCamera.position - otherPortal.position;
        transform.position = portal.position + distanceBetweenPortalPlayer;

        float rozanicadwochportali = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        Quaternion roznicaRotacjiPortali = Quaternion.AngleAxis(rozanicadwochportali, Vector3.up);
        Vector3 nowyKierunekKamery = roznicaRotacjiPortali * playerCamera.forward;
        nowyKierunekKamery = new Vector3(nowyKierunekKamery.x * -1, nowyKierunekKamery.y, nowyKierunekKamery.z * -1);
        transform.rotation = Quaternion.LookRotation(nowyKierunekKamery, Vector3.up);
    } 

}
