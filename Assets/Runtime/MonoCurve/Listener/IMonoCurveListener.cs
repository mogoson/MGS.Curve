/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IMonoCurveListener.cs
 *  Description  :  Listener for mono curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/3
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Curve
{
    /// <summary>
    /// Listener for mono curve.
    /// </summary>
    public interface IMonoCurveListener
    {
        /// <summary>
        /// Event on curve rebuild.
        /// </summary>
        /// <param name="curve">The target curve.</param>
        void OnCurveRebuild(IMonoCurve curve);
    }
}