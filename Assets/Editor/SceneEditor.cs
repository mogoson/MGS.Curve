/*************************************************************************
 *  Copyright © 2019 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SceneEditor.cs
 *  Description  :  Define scene editor.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0
 *  Date         :  2/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEditor;
using UnityEngine;

#if UNITY_5_3_OR_NEWER
using UnityEditor.SceneManagement;
#endif

namespace MGS.Curve.Editors
{
    public class SceneEditor : Editor
    {
#if UNITY_5_5_OR_NEWER
        protected readonly Handles.CapFunction CircleCap = Handles.CircleHandleCap;
        protected readonly Handles.CapFunction SphereCap = Handles.SphereHandleCap;
#else
        protected readonly Handles.DrawCapFunction CircleCap = Handles.CircleCap;
        protected readonly Handles.DrawCapFunction SphereCap = Handles.SphereCap;
#endif
#if UNITY_5_5_OR_NEWER
        protected void DrawFreeMoveHandle(Vector3 position, Quaternion rotation, float size, Vector3 snap, Handles.CapFunction capFunc, Action<Vector3> callback)
#else
        protected void DrawFreeMoveHandle(Vector3 position, Quaternion rotation, float size, Vector3 snap, Handles.DrawCapFunction capFunc, Action<Vector3> callback)
#endif
        {
            EditorGUI.BeginChangeCheck();
            var newPosition = Handles.FreeMoveHandle(position, Quaternion.identity, GetHandleSize(position) * size, snap, capFunc);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "CHANGE_FREE_MOVE_HANDLE");
                InvokeAction(callback, newPosition);
                MarkSceneDirty();
            }
        }

#if UNITY_5_5_OR_NEWER
        protected void DrawAdaptiveButton(Vector3 position, Quaternion direction, float size, float pickSize, Handles.CapFunction capFunc, Action callback)
#else
        protected void DrawAdaptiveButton(Vector3 position, Quaternion direction, float size, float pickSize, Handles.DrawCapFunction capFunc, Action callback)
#endif
        {
            var scale = GetHandleSize(position);
            if (Handles.Button(position, direction, size * scale, pickSize * scale, capFunc))
            {
                Undo.RecordObject(target, "CLICK_BUTTON");
                InvokeAction(callback);
                MarkSceneDirty();
            }
        }

        protected float GetHandleSize(Vector3 position)
        {
            return HandleUtility.GetHandleSize(position);
        }

        protected void MarkSceneDirty()
        {
#if UNITY_5_3_OR_NEWER
            EditorSceneManager.MarkAllScenesDirty();
#else
            EditorApplication.MarkSceneDirty();
#endif
        }

        protected void InvokeAction(Action action)
        {
            if (action != null)
            {
                action.Invoke();
            }
        }

        protected void InvokeAction<T>(Action<T> action, T arg)
        {
            if (action != null)
            {
                action.Invoke(arg);
            }
        }
    }
}