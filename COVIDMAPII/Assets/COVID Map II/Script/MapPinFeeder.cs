// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using System;
using System.Globalization;
using TMPro;
using UnityEngine;

/// <summary>
/// Adds <see cref="MapPin"/>s to the <see cref="MapPinLayer"/> based on the CSV file. Expected CSV file format is "Lat,Lon,Name,Type".
/// </summary>
public class MapPinFeeder : MonoBehaviour
{
    [SerializeField]
    private MapPinLayer _mapPinLayer = null;

    [SerializeField]
    private MapPin _mapPinPrefab = null;

    [SerializeField]
    private LatestCaseDatumList caseDatumListManager = null;

    private void Awake()
    {
        Debug.Assert(_mapPinLayer != null);
        Debug.Assert(_mapPinPrefab != null);

        _mapPinPrefab.gameObject.SetActive(false);
        
        // Generate a MapPin for each of the locations and add it to the layer.
        foreach (var neighbourhood in Neighbourhood.allNeighbourhoodsInNumericalOrder)
        {
            MapPin mapPin = Instantiate(_mapPinPrefab);
            mapPin.Location = new LatLon(neighbourhood.latitude, neighbourhood.longitude);
            _mapPinLayer.MapPins.Add(mapPin);

            NeighbourhoodPin neighbourhoodPin = mapPin.GetComponent<NeighbourhoodPin>();
            neighbourhoodPin.neighbourhoodRepresenting = neighbourhood;
            neighbourhoodPin.mapToBeAnimated = GetComponent<MapRenderer>();
            neighbourhoodPin.datumListToBePopulated = caseDatumListManager;
        }
    }
}
