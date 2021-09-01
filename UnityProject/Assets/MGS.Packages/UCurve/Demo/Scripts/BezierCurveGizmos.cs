/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BezierCurveGizmos.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/19/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve.Demo
{
    public class BezierCurveGizmos : MonoBehaviour
    {
        [SerializeField]
        BezierAnchor anchor = new BezierAnchor(Vector3.zero, Vector3.one, Vector3.forward, Vector2.one);

        BezierCurve curve = new BezierCurve();
        const float delta = 0.01f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            curve.Anchor = anchor;
            var p0 = curve.Evaluate(0); ;
            for (float k = delta; k < 1.0f; k += delta)
            {
                var p1 = curve.Evaluate(k);
                Gizmos.DrawLine(transform.TransformPoint(p0), transform.TransformPoint(p1));
                p0 = p1;
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.TransformPoint(anchor.from), transform.TransformPoint(anchor.from + anchor.inTangent));
            Gizmos.DrawLine(transform.TransformPoint(anchor.to), transform.TransformPoint(anchor.from + anchor.outTangent));
        }
    }
}