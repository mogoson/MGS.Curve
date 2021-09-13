[TOC]

# MGS.MonoCurve

## Summary

- Smooth 3D curve component for Unity project develop.

## Environment

- .Net Framework 3.5 or above.
- Unity 5.0 or above.

## Platform

- Windows

## Implemented

```C#
public class MonoSinCurve : MonoCurve{}
public class MonoEllipseCurve : MonoCurve{}
public class MonoHelixCurve : MonoCurve{}
public class MonoBezierCurve : MonoCurve{}
public class MonoHermiteCurve : MonoCurve{}
```

## Technology

### Transform

```C#
//World to local position.
return transform.TransformPoint(worldPos);
//Local to world position.
transform.InverseTransformPoint(localPos);

//World to local vector.
return transform.TransformPoint(worldVector);
//Local to world vector.
transform.InverseTransformPoint(localVector);
```

### Calculus

```C#
//Evaluate length of MonoSinCurve.
var halfPI = Mathf.PI * 0.5f;
var angularAbs = Mathf.Abs(args.angular);
var piece = Vector2.Distance(Vector2.zero, new Vector2(halfPI / angularAbs, args.amplitude));
var pieces = piece * angularAbs;
var segments = Mathf.RoundToInt(radian / halfPI);
return pieces * segments;

//Evaluate length of MonoEllipseCurve.
var ratio = Mathf.Abs(radian) / (Mathf.PI * 2);
if (args.semiMinorAxis == 0 || args.semiMajorAxis == 0)
{
    return 2 * Mathf.Abs(args.semiMinorAxis + args.semiMajorAxis) * ratio;
}
var minor = Mathf.Abs(args.semiMinorAxis);
var major = Mathf.Abs(args.semiMajorAxis);
var a = Mathf.Max(minor, major);
var b = Mathf.Min(minor, major);
return (2 * Mathf.PI * b + 4 * (a - b)) * ratio;

//Evaluate length of MonoHelixCurve, MonoBezierCurve and MonoHermiteCurve.
var length = 0f;
var t = 0f;
var p0 = EvaluateNormalized(t);
while (t < 1.0f)
{
    t = Mathf.Min(t + differ, 1.0f);
    var p1 = EvaluateNormalized(t);
    length += Vector3.Distance(p0, p1);
    p0 = p1;
}
return length;
```

## Usage

- Attach mono curve component to a game object.
- Adjust the args of curve component or edit curve in scene editor.

```tex
Select the MonoBezierCurve and drag the handle to adjust the anchor to see effect.
Press and hold the ALT into Tangent Edit mode, drag the handle to adjust the tangent of anchor.
If the start and end points are close, they will stick together.

Select the MonoHermiteCurve and drag the handle to adjust the anchor to see effect.
Press and hold the CTRL into Insert Edit mode, click the green handle to add a new anchor.
Press and hold the CTRL+SHIFT into Remove Edit mode, click the red handle to remove a anchor.
If do not use Auto Smooth,
Press and hold the ALT into Tangent Edit mode, drag the handle to adjust the tangent of anchor.
Press and hold the ALT+SHIFT into InOutTangent Edit mode, drag the handle to adjust the in out tangents of anchor.
If the start and end points are close, they will stick together.
```



- Evaluate point on the mono curve.

```C#
//Evaluate point on the mono curve at length.
var len = 0f;
var p0 = Target.Evaluate(len);
while (len < Target.Length)
{
    len = Mathf.Min(len + 0.01f, Target.Length);
    var p1 = Target.Evaluate(len);
    //Just for demo, you can use p0,p1 to do more things.
    Gizmos.DrawLine(p0, p1);
    p0 = p1;
}

//Evaluate the curve at normalized time int the range[0,1].
var t = 0f;
var p0 = EvaluateNormalized(t);
while (t < 1.0f)
{
    t = Mathf.Min(t + differ, 1.0f);
    var p1 = EvaluateNormalized(t);
    //Just for demo, you can use p0,p1 to do more things.
    Gizmos.DrawLine(p0, p1);
    p0 = p1;
}
```

## Demo

- Demos in the path "MGS.Packages/Curve/Demo/" provide reference to you.

## Source

- https://github.com/mogoson/MGS.MonoCurve.

------

Copyright © 2021 Mogoson.	mogoson@outlook.com