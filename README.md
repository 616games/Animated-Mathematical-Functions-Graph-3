# Animated-Mathematical-Functions-Graph-3
 Extends Graph and GraphFunctionsLibrary classes to allow for more than one input on any axis.  We are no longer limited to the XZ plane where X and Z are inputs with Y as the output.  This will allow us to create more complex and interesting graphs.
 
 Since the input parameters for these functions no longer correspond to the final X and Z coordinates, we use "u" and "v" instead.  The Vector3 struct is used to hold the input and output values, but only as a tuple and not as an actual vector.
 
 Example:  f(u, v) = [u, v, 0] describes the XY plane and f(u,v) = [u, 0, v] describes the XZ plane.
  
 Created in Unity 2020.3.11f1