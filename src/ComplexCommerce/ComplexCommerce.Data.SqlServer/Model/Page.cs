//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComplexCommerce.Data.SqlServer.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Page
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public System.Guid StoreLocaleId { get; set; }
        public string RouteUrl { get; set; }
        public int ContentTypeId { get; set; }
        public System.Guid ContentId { get; set; }
    
        public virtual StoreLocale StoreLocale { get; set; }
    }
}
