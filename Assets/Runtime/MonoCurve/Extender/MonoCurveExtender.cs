/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
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
    public abstract class MonoCurveExtender : MonoBehaviour, IMonoCurveExtender
    {
        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            OnCurveRebuild(GetComponent<IMonoCurve>());
        }

        /// <summary>
        /// Event on curve rebuild.
        /// </summary>
        /// <param name="curve">The target curve.</param>
        public abstract void OnCurveRebuild(IMonoCurve curve);
    }
}