﻿using System;

namespace ComplexCommerce.Data.Dto
{
    public class SiteMapProductDto
    {
        public Guid CategoryXProductId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ParentPageId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsUrlAbsolute { get; set; }
        public string MetaRobots { get; set; }
        public Guid DefaultCategoryPageId { get; set; }
        public int TenantId { get; set; }
        public int LocaleId { get; set; }
    }
}
