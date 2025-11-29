/*************************************************************************
 *  Copyright © 2025 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoCurveExtender.cs
 *  Description  :  Extender that base on mono curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/30/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Extender for mono curve.
    /// </summary>
    [ExecuteInEditMode]
    public abstract class MonoCurveExtender : MonoCurveListener, IMonoCurveExtender
    {
        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            OnCurveRebuild(GetComponent<IMonoCurve>());
        }
    }
}