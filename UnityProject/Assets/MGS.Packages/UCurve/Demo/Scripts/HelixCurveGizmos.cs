/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HelixCurveGizmos.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  7/25/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve.Demo
{
    public class HelixCurveGizmos : MonoBehaviour
    {
        [SerializeField]
        EllipseArgs top = new EllipseArgs(0, 1);

        [SerializeField]
        EllipseArgs bottom = new EllipseArgs(2, 3);

        [SerializeField]
        Vector3 from;

        [SerializeField]
        Vector3 to;

        [SerializeField]
        float altitude = 2.5f;

        [SerializeField]
        float radian = Mathf.PI * 4;

        HelixCurve curve = new HelixCurve();
        const float delta = 0.01f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            curve.top = top;
            curve.bottom = bottom;
            curve.altitude = altitude;
            curve.radian = radian;

            var p0 = curve.Evaluate(0) + from; ;
            for (float r = delta; r < radian; r += delta)
            {
                var k = r / radian;
                var p1 = curve.Evaluate(k) + Vector3.Lerp(from, to, k);
                Gizmos.DrawLine(transform.TransformPoint(p0), transform.TransformPoint(p1));
                p0 = p1;
            }
        }
    }
}