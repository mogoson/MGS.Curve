/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HermiteCurveGizmos.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  8/30/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.UCurve.Demo
{
    public class HermiteCurveGizmos : MonoBehaviour
    {
        [SerializeField]
        KeyFrame[] frames = new KeyFrame[]
        {
            new KeyFrame(0, Vector3.zero),
            new KeyFrame(1, Vector3.one),
            new KeyFrame(2, Vector3.right*2),
            new KeyFrame(3,new Vector3(1,1,-1)),
            new KeyFrame(4,Vector3.zero)
        };

        HermiteCurve curve = new HermiteCurve();
        const float delta = 0.01f;

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            curve.ClearFrames();
            curve.AddFrames(frames);
            curve.SmoothTangents(0);

            var p0 = curve.Evaluate(frames[0].time); ;
            for (float k = frames[0].time; k < frames[frames.Length - 1].time; k += delta)
            {
                var p1 = curve.Evaluate(k);
                Gizmos.DrawLine(transform.TransformPoint(p0), transform.TransformPoint(p1));
                p0 = p1;
            }

            Gizmos.color = Color.grey;
        }
    }
}