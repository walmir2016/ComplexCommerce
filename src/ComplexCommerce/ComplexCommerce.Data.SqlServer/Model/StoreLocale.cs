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
    
    public partial class StoreLocale
    {
        public StoreLocale()
        {
            this.Category = new HashSet<Category>();
            this.ProductXStoreLocale = new HashSet<ProductXStoreLocale>();
            this.Page = new HashSet<Page>();
        }
    
        public System.Guid Id { get; set; }
        public System.Guid StoreId { get; set; }
        public int LocaleId { get; set; }
        public string SiteMap { get; set; }
    
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<ProductXStoreLocale> ProductXStoreLocale { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Page> Page { get; set; }
    }
}
