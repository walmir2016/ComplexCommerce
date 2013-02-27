//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// Architectural overview and usage guide: 
// http://blogofrab.blogspot.com/2010/08/maintenance-free-mocking-for-unit.html
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Common;

namespace ComplexCommerce.Data.SqlServer.Model
{
    /// <summary>
    /// The interface for the specialised object context. This contains all of
    /// the <code>ObjectSet</code> properties that are implemented in both the
    /// functional context class and the mock context class.
    /// </summary>
    public interface IComplexCommerce : IObjectContext
    {
        IObjectSet<Category> Category { get; }
        IObjectSet<CategoryXProductXStoreLocale> CategoryXProductXStoreLocale { get; }
        IObjectSet<Chain> Chain { get; }
        IObjectSet<Product> Product { get; }
        IObjectSet<ProductXStoreLocale> ProductXStoreLocale { get; }
        IObjectSet<Page> Page { get; }
        IObjectSet<Store> Store { get; }
        IObjectSet<StoreLocale> StoreLocale { get; }
    }
}