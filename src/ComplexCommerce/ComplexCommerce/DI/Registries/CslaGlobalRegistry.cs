﻿using System;
using StructureMap.Configuration.DSL;
using ComplexCommerce.Business;
using ComplexCommerce.Business.Context;
using ComplexCommerce.Business.Text;
using ComplexCommerce.Business.Routing;

namespace ComplexCommerce.DI.Registries
{
    // Register Dependencies required by both Csla Client and Server

    // Note that dependencies to CSLA objects should be injected as
    // properties (setter injection) rather than injecting through a
    // constructor.
    internal class CslaGlobalRegistry : Registry
    {
        public CslaGlobalRegistry()
        {
            this.Scan(scan =>
            {
                scan.AssemblyContainingType<IApplicationContext>();
                scan.WithDefaultConventions();
            });


            // We create a new Setter Injection Policy that
            // forces StructureMap to inject all public properties
            // where the Property Type equals 'IApplicationContext'
            this.SetAllProperties(p =>
            {
                p.TypeMatches(t => t == typeof(IApplicationContext));
            });

            this.SetAllProperties(p =>
            {
                p.TypeMatches(t => t == typeof(IUrlBuilder));
            });

            this.SetAllProperties(p =>
            {
                p.TypeMatches(t => t == typeof(IParentUrlPageListFactory));
            });


            

        }
    }
}