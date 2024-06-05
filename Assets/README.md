[TOC]

# MGS.Curve

## Summary

- Smooth 3D curve component for Unity project develop.

## Platform

- Windows

## Environment

- .Net Framework 3.5 or above.
- Unity 5.0 or above.

## Demand

- Create smooth **Curve** in 3D space.
- Create **Renderer** to show curve in scene.
- Create **Collider** to check trigger in scene.
- Create **Cacher** to build curve to cache file and load curve from cache file.

## Usage

- Attach mono curve component to a game object.

```tex
MonoHermiteCurve MonoBezierCurve MonoHelixCurve MonoEllipseCurve MonoSinCurve
```

- Adjust the parameters of curve component or edit curve in scene editor.

```tex
Select the MonoBezierCurve and drag the handle to adjust the anchor to see effect.
Press and hold the ALT into Tangent Edit mode, drag the handle to adjust the tangent of anchor.
If the start and end points are close, they will stick together.

Select the MonoHermiteCurve and drag the handle to adjust the anchor to see effect.
Press and hold the CTRL, click the green handle to add a new anchor.
Press and hold the CTRL+SHIFT, click the red handle to remove a anchor.
If do not use Auto Smooth,
Press and hold the ALT, click the blue handle to open Tangent editor and drag the
 cyan handle to adjust the tangent of anchor; on this mode, Press and hold the SHIFT
 to open In and Out tangent editor, drag the cyan and green handle to adjust the
 tangents of anchor.
Press and hold the ALT+COMMAND into All Tangents mode.
If the start and end points are close, they will stick together.
```

- Attach mono curve renderer component to the mono curve game object to renderer curve in scene  if need.
```tex
MonoCurveLineRenderer
```

- Attach mono curve collider component to the mono curve game object if need.
```tex
MonoCurveCapsuleCollider
```

- Attach mono curve cacher component to the mono curve game object if need.
```tex
MonoBezierCurveCacher MonoHermiteCurveCacher
```

------

Copyright © 2021 Mogoson.	mogoson@outlook.com