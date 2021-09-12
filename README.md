[TOC]

# MGS.UCurve

## Summary

- Smooth 3D curve for Unity project develop.

## Environment

- .Net Framework 3.5 or above.
- Unity 5.0 or above.

## Platform

- Windows

## Implemented

```C#
public class SinCurve : ITimeCurve{}
public class EllipseCurve : ITimeCurve{}
public class HelixCurve : ITimeCurve{}
public class BezierCurve : ITimeCurve{}
public class HermiteCurve : ITimeCurve{}
```

## Technology

### Hermite Polynomial Structure

```C#

```

### Tangent Smooth

```C#

```

## Usage

- New a Curve and Set Args to it.

```C#
var curve = new HermiteCurve();
curve.AddFrames(frames);
curve.SmoothTangents();//If need SmoothTangents Auto.
```

- Use time lapse to Evaluate target Vector3.

```C#
var p0 = curve.Evaluate(frames[0].time);
for (float t = frames[0].time; t < frames[frames.Length - 1].time; t += delta)
{
    var p1 = curve.Evaluate(t);
    //Just for demo, you can use p0,p1 to do more things.
    Gizmos.DrawLine(transform.TransformPoint(p0), transform.TransformPoint(p1));
    p0 = p1;
}
```

## Demo

- Demos in the path "MGS.Packages/UCurve/Demo/" provide reference to you.

## Preview

- MonoHermiteCurve

![](./Attachment/images/MonoHermiteCurve.png)

- MonoBezierCurve

![](./Attachment/images/MonoBezierCurve.png)

- MonoHelixCurve

![](./Attachment/images/MonoHelixCurve.png)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com