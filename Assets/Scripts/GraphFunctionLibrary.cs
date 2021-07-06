using System;
using UnityEngine;

public static class GraphFunctionLibrary
{
    #region --Custom Methods--
    
    /// <summary>
    /// Returns the method that matches the GraphFunctionType specified.
    /// </summary>
    public static GraphFunction GetGraphFunction(GraphFunctionType _type)
    {
        switch (_type)
        {
            case GraphFunctionType.Line:
                return Line;

            case GraphFunctionType.Squared:
                return Squared;

            case GraphFunctionType.Cubed:
                return Cubed;
            
            case GraphFunctionType.Wave:
                return Wave;

            case GraphFunctionType.MultiWave:
                return MultiWave;

            case GraphFunctionType.MultiWave2:
                return MultiWave2;

            case GraphFunctionType.Ripple:
                return Ripple;
            
            case GraphFunctionType.CircleFlat:
                return CircleFlat;
            
            case GraphFunctionType.CylinderHollow:
                return CylinderHollow;
            
            case GraphFunctionType.DiscFlat:
                return DiscFlat;
            
            case GraphFunctionType.SpiralStaircase:
                return SpiralStaircase;
            
            case GraphFunctionType.HourGlass:
                return HourGlass;
            
            case GraphFunctionType.Onion:
                return Onion;
            
            case GraphFunctionType.Sphere:
                return Sphere;
            
            case GraphFunctionType.SpherePulsing:
                return SpherePulsing;
            
            case GraphFunctionType.SphereVerticalBands:
                return SphereVerticalBands;
            
            case GraphFunctionType.SphereHorizontalBands:
                return SphereHorizontalBands;
            
            case GraphFunctionType.SphereTwistingBands:
                return SphereTwistingBands;
            
            case GraphFunctionType.SphereTwistingBandsSpinning:
                return SphereTwistingBandsSpinning;
            
            case GraphFunctionType.SphereCylinder:
                return SphereCylinder;
            
            case GraphFunctionType.SpindleTorus:
                return SpindleTorus;
            
            case GraphFunctionType.HornTorus:
                return HornTorus;
            
            case GraphFunctionType.RingTorus:
                return RingTorus;
            
            case GraphFunctionType.TwistedStarTorus:
                return TwistedStarTorus;
            
            case GraphFunctionType.TwistedStarTorusTwisting:
                return TwistedStarTorusTwisting;
        }

        return null;
    }
    
    /// <summary>
    /// Graphs a line.
    /// f(x) = x.
    /// </summary>
    private static Vector3 Line(float _xInput, float _zInput, float _time)
    {
        Vector3 _tuple;
        _tuple.x = _xInput;
        _tuple.y = _xInput;
        _tuple.z = 0;
        
        return _tuple;
    }

    /// <summary>
    /// Graphs a parabola.
    /// f(x) = x * x.
    /// </summary>
    private static Vector3 Squared(float _xInput, float _zInput, float _time)
    {
        Vector3 _tuple;
        _tuple.x = _xInput;
        _tuple.y = _xInput * _xInput;
        _tuple.z = 0;
        
        return _tuple;
    }

    /// <summary>
    /// Graphs a cubed function.
    /// f(x) = x * x * x.
    /// </summary>
    private static Vector3 Cubed(float _xInput, float _zInput, float _time)
    {
        Vector3 _tuple;
        _tuple.x = _xInput;
        _tuple.y = _xInput * _xInput * _xInput;
        _tuple.z = 0;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a single sine wave with its full period of 2PI and animates over time.
    /// f(x, z, t) = sin(PI(x + z + t)). 
    /// </summary>
    private static Vector3 Wave(float _xInput, float _zInput, float _time)
    {
        Vector3 _tuple;
        _tuple.x = _xInput;
        _tuple.y = Mathf.Sin(Mathf.PI * (_xInput + _zInput + _time));
        _tuple.z = _zInput;

        return _tuple;
    }

    /// <summary>
    /// Graphs two sine waves added together with different frequencies and animates over time.
    /// f1(x, t) = sin(PI(x + t))
    /// f2(z, t) = .5sin(2PI(z + t))
    /// divisor = 1.5 (to make sure the result fits within our -1 to 1 domain)
    /// (f1 + f2) / 1.5
    /// </summary>
    private static Vector3 MultiWave(float _xInput, float _zInput, float _time)
    {
        float _f1 = Mathf.Sin(Mathf.PI * (_xInput + _time));
        float _f2 = .5f * Mathf.Sin(2 * Mathf.PI * (_zInput + _time));

        Vector3 _tuple;
        _tuple.x = _xInput;
        _tuple.y = (_f1 + _f2) / 1.5f;
        _tuple.z = _zInput;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs three sine waves added together with different frequencies and animates over time.
    /// f1(x, t) = sin(PI(x + .5t))
    /// f2(z, t) = .5sin(2PI(x + t))
    /// f3(x, z, t) = .5sin(PI(x + z + .25t))
    /// divisor = 2.5 (to make sure the result fits within our -1 to 1 domain)
    /// (f1 + f2 + f3) / 2.5
    /// </summary>
    private static Vector3 MultiWave2(float _xInput, float _zInput, float _time)
    {
        float _f1 = Mathf.Sin(Mathf.PI * (_xInput + .5f *_time));
        float _f2 = .5f * Mathf.Sin(2 * Mathf.PI * (_zInput + _time));
        float _f3 = .5f * Mathf.Sin(Mathf.PI * (_xInput + _zInput +.25f * _time));

        Vector3 _tuple;
        _tuple.x = _xInput;
        _tuple.y = (_f1 + _f2 + _f3) / 2.5f;
        _tuple.z = _zInput;

        return _tuple;
    }

    /// <summary>
    /// Graphs a sine wave oscillating away from the center of the graph and decreasing its amplitude over time.
    /// d = distance from center (absolute value of x input).
    /// f(d, t) = sin(PI(4d - t))
    /// divisor = 1 + 10d (to decrease amplitude over time)
    /// f / (1 + 10d)
    /// </summary>
    private static Vector3 Ripple(float _xInput, float _zInput, float _time)
    {
        float _distance = Mathf.Sqrt(_xInput * _xInput + _zInput * _zInput);
        float _f = Mathf.Sin(Mathf.PI * (4f * _distance - _time));

        Vector3 _tuple;
        _tuple.x = _xInput;
        _tuple.y = _f / (1f + 10f * _distance);
        _tuple.z = _zInput;

        return _tuple;
    }

    /// <summary>
    /// Graphs the outline of a circle on the XZ plane.
    /// Change the input from "u" to "v" to flip the circle upright.
    /// Change the "f" positions to draw it on a different plane.
    /// f1(u) = Sin(PI(u))
    /// f2(u) = Cos(PI(u))
    /// </summary>
    private static Vector3 CircleFlat(float _u, float _v, float _time)
    {
        float _f1 = Mathf.Sin(Mathf.PI * _u);
        float _f2 = Mathf.Cos(Mathf.PI * _u);

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = 0;
        _tuple.z = _f2;

        return _tuple;
    }

    /// <summary>
    /// Graphs a CircleFlat and "v" is used as the height to create a cylinder.
    /// f1(u) = Sin(PI(u))
    /// f2(u) = Cos(PI(u))
    /// </summary>
    private static Vector3 CylinderHollow(float _u, float _v, float _time)
    {
        float _f1 = Mathf.Sin(Mathf.PI * _u);
        float _f2 = Mathf.Cos(Mathf.PI * _u);

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _v;
        _tuple.z = _f2;

        return _tuple;
    }

    /// <summary>
    /// Graphs a CircleFlat and then uses "v" to define the radius which fills in the center to create a disc on the XZ plane.
    /// float _radius = Cos(.5(PI(v)))
    /// f1(u) = _r * Sin(PI(u))
    /// f2(u) = _r * Cos(PI(u))
    /// </summary>
    private static Vector3 DiscFlat(float _u, float _v, float _time)
    {
        float _radius = Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = 0;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a DiscFlat and adds "u" for height to create a spiral staircase.
    /// float _radius = Cos(.5(PI(v)))
    /// f1(u) = _r * Sin(PI(u))
    /// f2(u) = _r * Cos(PI(u))
    /// </summary>
    private static Vector3 SpiralStaircase(float _u, float _v, float _time)
    {
        float _radius = Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _u;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a DiscFlat and adds "v" for height with sine instead of cosine for the radius to create an hour glass (or two half spheres flipped).
    /// float _radius = Sin(.5(PI(v)))
    /// f1(u) = _r * Sin(PI(u))
    /// f2(u) = _r * Cos(PI(u))
    /// </summary>
    private static Vector3 HourGlass(float _u, float _v, float _time)
    {
        float _radius = Mathf.Sin(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _v;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a CylinderHollow where the top and bottom of the cylinder are closed to a point (a collapsing radius).
    /// float _radius = Cos(.5(PI(v)))
    /// f1(u) = _r * Sin(PI(u))
    /// f2(u) = _r * Cos(PI(u))
    /// </summary>
    private static Vector3 Onion(float _u, float _v, float _time)
    {
        float _radius = Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _v;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs an Onion where the collapsed radius is rounded out by the addition of sine of "v" for the height instead of just "v".
    /// _radius = Cos(.5(PI(v)))
    /// f1(u) = _r * Sin(PI(u))
    /// f2(u) = _r * Cos(PI(u))
    /// f3(v) = Sin(.5(PI(v))
    /// </summary>
    private static Vector3 Sphere(float _u, float _v, float _time)
    {
        float _radius = Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);
        float _f3 = Mathf.Sin(.5f * (Mathf.PI * _v));

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _f3;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a Sphere where the collapsing radius now scales over time.
    /// _changeOverTime = .5 + .5Sin(PI(t))
    /// _radius = _changeOverTime * Cos(.5(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(u) = _radius * Cos(PI(u))
    /// f3(v) = _changeOvertime * Sin(.5(PI(v))
    /// </summary>
    private static Vector3 SpherePulsing(float _u, float _v, float _time)
    {
        float _changeOverTime = .5f + .5f * Mathf.Sin(Mathf.PI * _time);
        float _radius = _changeOverTime * Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);
        float _f3 = _changeOverTime * Mathf.Sin(.5f * (Mathf.PI * _v));

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _f3;
        _tuple.z = _f2;

        return _tuple;
    }

    /// <summary>
    /// Graphs a SpherePulsing and removes the change in the radius over time by replacing time with "u" as a multiplier.
    /// _multiplier = .9 + .1Sin(PI(8u))
    /// _radius = _multiplier * Cos(.5(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(u) = _radius * Cos(PI(u))
    /// f3(v) = _multiplier * Sin(.5(PI(v))
    /// </summary>
    private static Vector3 SphereVerticalBands(float _u, float _v, float _time)
    {
        float _multiplier = .9f + .1f * Mathf.Sin(Mathf.PI * 8f * _u);
        float _radius = _multiplier * Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);
        float _f3 = _multiplier * Mathf.Sin(.5f * (Mathf.PI * _v));

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _f3;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a SphereVerticalBands and replaces "u" with "v" in the multiplier.
    /// _multiplier = .9 + .1Sin(PI(8u))
    /// _radius = _multiplier * Cos(.5(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(u) = _radius * Cos(PI(u))
    /// f3(v) = _multiplier * Sin(.5(PI(v))
    /// </summary>
    private static Vector3 SphereHorizontalBands(float _u, float _v, float _time)
    {
        float _multiplier = .9f + .1f * Mathf.Sin(Mathf.PI * 8f * _v);
        float _radius = _multiplier * Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);
        float _f3 = _multiplier * Mathf.Sin(.5f * (Mathf.PI * _v));

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _f3;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a combined version of SphereVerticalBands and SphereHorizontalBands with twisting bands.
    /// multiplier = .9 + .1Sin(PI(6u + 4v))
    /// _radius = _multiplier * Cos(.5(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(u) = _radius * Cos(PI(u))
    /// f3(v) = _multiplier * Sin(.5(PI(v))
    /// </summary>
    private static Vector3 SphereTwistingBands(float _u, float _v, float _time)
    {
        float _multiplier = .9f + .1f * Mathf.Sin(Mathf.PI * (6f * _u + 4f * _v));
        float _radius = _multiplier * Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);
        float _f3 = _multiplier * Mathf.Sin(.5f * (Mathf.PI * _v));

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _f3;
        _tuple.z = _f2;

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a SphereTwistingBands and animates over time.
    /// _multiplier = .9 + .1Sin(PI(6u + 4v + t))
    /// _radius = _multiplier * Cos(.5(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(u) = _radius * Cos(PI(u))
    /// f3(v) = _multiplier * Sin(.5(PI(v))
    /// </summary>
    private static Vector3 SphereTwistingBandsSpinning(float _u, float _v, float _time)
    {
        float _multiplier = .9f + .1f * Mathf.Sin(Mathf.PI * (6f * _u + 4f * _v + _time));
        float _radius = _multiplier * Mathf.Cos(.5f * (Mathf.PI * _v));
        float _f1 = _radius * Mathf.Sin(Mathf.PI * _u);
        float _f2 = _radius * Mathf.Cos(Mathf.PI * _u);
        float _f3 = _multiplier * Mathf.Sin(.5f * (Mathf.PI * _v));

        Vector3 _tuple;
        _tuple.x = _f1;
        _tuple.y = _f3;
        _tuple.z = _f2;

        return _tuple;
    }

    /// <summary>
    /// Graphs a combination of Sphere and Cylinder.
    ///_multiplier = 1
    /// _radius = _multiplier * _radius(Cos(PI(.5v))) + .5
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(v) = _multiplier * Sin(PI(.5v))
    /// f3(u) = _radius * Cos(PI(u))
    /// </summary>
    private static Vector3 SphereCylinder(float _u, float _v, float _time)
    {
        float _multiplier = 1;
        float _radius = _multiplier * Mathf.Cos(Mathf.PI * .5f * _v) + .5f;

        Vector3 _tuple;
        _tuple.x = _radius * Mathf.Sin(Mathf.PI * _u);
        _tuple.y = _multiplier * Mathf.Sin(Mathf.PI * .5f * _v);
        _tuple.z = _radius * Mathf.Cos(Mathf.PI * _u);

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a SphereCylinder and changes .5PI to just PI to cause the inner section to close but intersect itself.
    ///_multiplier = 1
    /// _radius = _multiplier * _radius(Cos(PI(v))) + .5
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(v) = _multiplier * Sin(PI(v))
    /// f3(u) = _radius * Cos(PI(u))
    /// </summary>
    private static Vector3 SpindleTorus(float _u, float _v, float _time)
    {
        float _multiplier = 1;
        float _radius = _multiplier * Mathf.Cos(Mathf.PI * _v) + .5f;

        Vector3 _tuple;
        _tuple.x = _radius * Mathf.Sin(Mathf.PI * _u);
        _tuple.y = _multiplier * Mathf.Sin(Mathf.PI * _v);
        _tuple.z = _radius * Mathf.Cos(Mathf.PI * _u);

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a SpindleTorus that doesn't intersect itself, but doesn't have a hole on top or bottom either.
    /// Introduces the major and minor radii.
    ///_majorRadius = 1
    /// _minorRadius = 1
    /// _radius = _majorRadius + _minorRadius * _radius(Cos(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(v) = _multiplier * Sin(PI(v))
    /// f3(u) = _radius * Cos(PI(u))
    /// </summary>
    private static Vector3 HornTorus(float _u, float _v, float _time)
    {
        float _majorRadius = 1;
        float _minorRadius = 1;
        float _radius = _majorRadius + _minorRadius * Mathf.Cos(Mathf.PI * _v);
        
        Vector3 _tuple;
        _tuple.x = _radius * Mathf.Sin(Mathf.PI * _u);
        _tuple.y = _majorRadius * Mathf.Sin(Mathf.PI * _v);
        _tuple.z = _radius * Mathf.Cos(Mathf.PI * _u);

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a SpindleTorus that doesn't intersect itself, but doesn't have a hole on top or bottom either.
    /// Introduces the major and minor radii.
    ///_majorRadius = .75
    /// _minorRadius = .25
    /// _radius = _majorRadius + _minorRadius * _radius(Cos(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(v) = _multiplier * Sin(PI(v))
    /// f3(u) = _radius * Cos(PI(u))
    /// </summary>
    private static Vector3 RingTorus(float _u, float _v, float _time)
    {
        float _majorRadius = .75f;
        float _minorRadius = .25f;
        float _radius = _majorRadius + _minorRadius * Mathf.Cos(Mathf.PI * _v);
        
        Vector3 _tuple;
        _tuple.x = _radius * Mathf.Sin(Mathf.PI * _u);
        _tuple.y = _minorRadius * Mathf.Sin(Mathf.PI * _v);
        _tuple.z = _radius * Mathf.Cos(Mathf.PI * _u);

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a RingTorus and applies sine of u to major radius and sine of v to minor radius to create a star pattern.
    ///_majorRadius = .75 + .1Sin(PI(6u))
    /// _minorRadius = .25 + .05Sin(PI(8v))
    /// _radius = _majorRadius + _minorRadius * _radius(Cos(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(v) = _multiplier * Sin(PI(v))
    /// f3(u) = _radius * Cos(PI(u))
    /// </summary>
    private static Vector3 TwistedStarTorus(float _u, float _v, float _time)
    {
        float _majorRadius = .75f + .1f * Mathf.Sin(Mathf.PI * (6f * _u));
        float _minorRadius = .25f + .05f * Mathf.Sin(Mathf.PI * (8f * _v));
        float _radius = _majorRadius + _minorRadius * Mathf.Cos(Mathf.PI * _v);
        
        Vector3 _tuple;
        _tuple.x = _radius * Mathf.Sin(Mathf.PI * _u);
        _tuple.y = _minorRadius * Mathf.Sin(Mathf.PI * _v);
        _tuple.z = _radius * Mathf.Cos(Mathf.PI * _u);

        return _tuple;
    }
    
    /// <summary>
    /// Graphs a TwistedStarTorus added "u" to the minor radius and changes both radii over time.
    ///_majorRadius = .75 + .1Sin(PI(6u + .5t))
    /// _minorRadius = .25 + .05Sin(PI(8u + 4v + 2t))
    /// _radius = _majorRadius + _minorRadius * _radius(Cos(PI(v)))
    /// f1(u) = _radius * Sin(PI(u))
    /// f2(v) = _multiplier * Sin(PI(v))
    /// f3(u) = _radius * Cos(PI(u))
    /// </summary>
    private static Vector3 TwistedStarTorusTwisting(float _u, float _v, float _time)
    {
        float _majorRadius = .75f + .1f * Mathf.Sin(Mathf.PI * (6f * _u + .5f * _time));
        float _minorRadius = .25f + .05f * Mathf.Sin(Mathf.PI * (8f * _u + 4f * _v + 2 * _time));
        float _radius = _majorRadius + _minorRadius * Mathf.Cos(Mathf.PI * _v);
        
        Vector3 _tuple;
        _tuple.x = _radius * Mathf.Sin(Mathf.PI * _u);
        _tuple.y = _minorRadius * Mathf.Sin(Mathf.PI * _v);
        _tuple.z = _radius * Mathf.Cos(Mathf.PI * _u);

        return _tuple;
    }

    #endregion
    
}
