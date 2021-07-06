using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    #region --Fields / Properties
    
    /// <summary>
    /// Prefab of the point game object used to populate the graph.
    /// </summary>
    [SerializeField]
    private GameObject _pointPrefab;

    /// <summary>
    /// How many points will be plotted.
    /// </summary>
    [SerializeField, Range(10, 100)]
    private int _resolution;

    /// <summary>
    /// The type of graph to be created.
    /// </summary>
    [SerializeField]
    private GraphFunctionType _graphFunctionType;

    /// <summary>
    /// A List of all the points instantiated to create the graph.
    /// </summary>
    private readonly List<GameObject> _points = new List<GameObject>();

    /// <summary>
    /// Represents the following equation:  (desired domain range) / (desired resolution)
    /// </summary>
    private float _scaleMultiplier;

    /// <summary>
    /// The scale value to be applied to all points.
    /// </summary>
    private Vector3 _scale;

    #endregion
    
    #region --Unity Specific Methods--
    
    private void Start()
    {
        Init();
        Graph3D();
    }

    private void Update()
    {
        AnimateGraph();
    }
    
    #endregion
    
    #region --Custom Methods--

    private void Init()
    {
        //Scale is adjusted to make sure all points fit within our domain of -1 to 1 based on how many points are set for the resolution.
        _scaleMultiplier = 2f / _resolution;
        _scale = Vector3.one * _scaleMultiplier;
    }
    
    /// <summary>
    /// Creates a three dimensional representation of the selected _graphFunctionType.
    /// </summary>
    private void Graph3D()
    {
        for (int i = 0; i < _resolution * _resolution; i++)
        {
            GameObject _point = Instantiate(_pointPrefab, transform, true);
            _points.Add(_point);
            _point.transform.localScale = _scale;
        }
    }

    /// <summary>
    /// Animates the points of the graph based on the currently selected _graphFunctionType.
    /// </summary>
    private void AnimateGraph()
    {
        GraphFunction _function = GraphFunctionLibrary.GetGraphFunction(_graphFunctionType);
        
        //Iterate through all points in every row and update their positions based on the values of "u" and "v" passed into the desired GraphFunctionType.
        //x represents a row of points positioned along the X axis and we need to reset its value at the end of each row (once x reaches the number of points (resolution)).
        //z represents a row of points positioned along the Z axis and we need to increase its value only when x starts to update a new row.
        //Position each point for each row along the X axis from the left shifted right .5 units (radius) so they aren't overlapping.
        //Factor in the point's adjusted scale.
        //Adjust the entire range to the left 1 unit so all points fit within -1 to 1 on the X axis.
        //x and z share the first point's offset and scale values, which is why we set "v"'s initial offset value such that the value of z is 0.
        float _v = .5f * _scaleMultiplier - 1f;
        for (int _xAxisRowID = 0, _xAxisPointID = 0, _zAxisRowID = 0; _xAxisRowID < _resolution * _resolution; _xAxisRowID++, _xAxisPointID++)
        {
            if (_xAxisPointID == _resolution)
            {
                _xAxisPointID = 0;
                _zAxisRowID++;
                
                //We only need to update the first point in a new row on the z axis once all the points in the row along the x axis have been updated.
                _v = (_zAxisRowID + 0.5f) * _scaleMultiplier - 1f;
            }
            
            float _u = (_xAxisPointID + .5f) * _scaleMultiplier - 1f;
            GameObject _point = _points[_xAxisRowID];
            _point.transform.position = _function(_u, _v, Time.time);
        }
    }

    #endregion
    
}
