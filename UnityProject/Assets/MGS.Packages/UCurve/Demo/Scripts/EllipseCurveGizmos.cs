/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  EllipseCurveGizmos.cs
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
    public class EllipseCurveGizmos : MonoBehaviour
    {
        [SerializeField]
        EllipseArgs args = new EllipseArgs(1, 2);

        [SerializeField]
        float min = -Mathf.PI;

        [SerializeField]
        float max = Mathf.PI;

        [SerializeField]
        Vector3 from;

        [SerializeField]
        Vector3 to;

        EllipseCurve curve = new EllipseCurve();
        const float delta = 0.01f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            curve.args = args;
            var p0 = curve.Evaluate(min) + from;
            for (float r = min + delta; r < max; r += delta)
            {
                var p1 = curve.Evaluate(r) + Vector3.Lerp(from, to, (r - min) / (max - min));
                Gizmos.DrawLine(transform.TransformPoint(p0), transform.TransformPoint(p1));
                p0 = p1;
            }
        }
    }
}