﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/* Copyright (c) 2018 Sloan Kelly 
 
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software. 
*/

/// <summary>
/// Handles import window inputs
/// </summary>
internal sealed class ImportMapWrapper
{
    /// <summary>
    /// Materials and values to pass to the factory classes
    /// </summary>
    private EditorImportWindow _window;
    private string _mapFile;
    private Material _roadMaterial;
    private Material _footwayMaterial;
    private Material _buildingMaterial;
    private Material _roofMaterial;
    private Material _greenMaterial;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="window">Reference to editor window</param>
    /// <param name="mapFile">Path to map file</param>
    /// <param name="roadMaterial">Road material</param>
    /// <param name="footwayMaterial">Footway material</param>
    /// <param name="buildingMaterial">building material</param>
    /// <param name="roofMaterial">Rooftop material</param>
    /// <param name="greenMaterial">Green material</param>
    public ImportMapWrapper(EditorImportWindow window, string mapFile, Material roadMaterial, Material footwayMaterial,
                            Material buildingMaterial, Material roofMaterial, Material greenMaterial)
    {
        _window = window;
        _mapFile = mapFile;
        _roadMaterial = roadMaterial;
        _footwayMaterial = footwayMaterial;
        _buildingMaterial = buildingMaterial;
        _roofMaterial = roofMaterial;
        _greenMaterial = greenMaterial;
    }

    //Calls the factory classes and passes the values of the import window inputs
    public void Import()
    {
        var xmlBaseFactory = new XmlBaseFactory();
        xmlBaseFactory.Read(_mapFile);

        var buildingFactory = new BuildingFactory(xmlBaseFactory, _buildingMaterial);
        var roofFactory = new RoofFactory(xmlBaseFactory, _roofMaterial);
        var roadFactory = new RoadFactory(xmlBaseFactory, _roadMaterial, _footwayMaterial);
        var environmentFactory = new EnvironmentFactory(xmlBaseFactory, _greenMaterial);

    }
}
