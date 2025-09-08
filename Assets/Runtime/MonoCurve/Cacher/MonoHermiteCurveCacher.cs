/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MonoHermiteCurveCacher.cs
 *  Description  :  Cacher for mono hermite curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  9/30/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace MGS.Curve
{
    /// <summary>
    /// Cacher for mono hermite curve.
    /// </summary>
    [AddComponentMenu("MGS/Curve/MonoHermiteCurveCacher")]
    [RequireComponent(typeof(MonoHermiteCurve))]
    public class MonoHermiteCurveCacher : MonoCurveCacher
    {
        /// <summary>
        /// Host curve of cacher.
        /// </summary>
        [SerializeField]
        [HideInInspector]
        protected MonoHermiteCurve curve;

        /// <summary>
        /// Reset component.
        /// </summary>
        protected virtual void Reset()
        {
            curve = GetComponent<MonoHermiteCurve>();
        }

        /// <summary>
        /// Serialize mono curve to string content.
        /// </summary>
        /// <returns></returns>
        protected override string SerializeCurve()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new FieldContractResolver()
            };
            return JsonConvert.SerializeObject(curve.anchors, settings);
        }

        /// <summary>
        /// Deserialize mono curve from string content.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected override bool DeserializeCurve(string content)
        {
            try
            {
                var anchors = JsonConvert.DeserializeObject<List<HermiteAnchor>>(content);
                if (anchors == null)
                {
                    Debug.LogError("The anchors is null.");
                    return false;
                }

                curve.anchors = anchors;
                curve.Rebuild();
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogErrorFormat("{0}\r\n{1}", ex.Message, ex.StackTrace);
                return false;
            }
        }
    }
}