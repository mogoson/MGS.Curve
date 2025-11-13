/*************************************************************************
 *  Copyright © 2025 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FieldOnlyContractResolver.cs
 *  Description  :  Contract resolver for field.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  8/15/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MGS.Curve
{
    /// <summary>
    /// Contract resolver for field only.
    /// </summary>
    public class FieldOnlyContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Create json Property only for field.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (member.MemberType != MemberTypes.Field)
            {
                property.Ignored = true;
            }
            return property;
        }
    }
}