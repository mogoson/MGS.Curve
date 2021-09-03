/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SinCurveDemo.cs
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
    public class SinCurveGizmos : MonoBehaviour
    {
        [SerializeField]
        SinArgs args = new SinArgs(1, 1, 0);

        [SerializeField]
        float min = -Mathf.PI;

        [SerializeField]
        float max = Mathf.PI;

        [SerializeField]
        Vector3 from;

        [SerializeField]
        Vector3 to;

        SinCurve curve = new SinCurve();
        const float delta = 0.01f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            curve.args = args;
            var p0 = curve.Evaluate(min) + from;
            for (float x = min + delta; x < max; x += delta)
            {
                var p1 = curve.Evaluate(x) + Vector3.Lerp(from, to, (x - min) / (max - min));
                Gizmos.DrawLine(transform.TransformPoint(p0), transform.TransformPoint(p1));
                p0 = p1;
            }
        }
    }
}