﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using ComplexCommerce.Business.Context;
using ComplexCommerce.Business.Routing;

namespace ComplexCommerce.Business.Text
{
    public class UrlBuilder
        : IUrlBuilder
    {
        public UrlBuilder(
            IApplicationContext appContext,
            IParentUrlPageListFactory parentUrlPageListFactory
            )
        {
            if (appContext == null)
                throw new ArgumentNullException("appContext");
            if (parentUrlPageListFactory == null)
                throw new ArgumentNullException("parentUrlPageListFactory");
            
            this.appContext = appContext;
            this.parentUrlPageListFactory = parentUrlPageListFactory;
        }

        private readonly IApplicationContext appContext;
        private readonly IParentUrlPageListFactory parentUrlPageListFactory;

        public string BuildPath(string url, bool isUrlAbsolute, Guid parentPageId, int tenantId, int localeId)
        {
            var defaultLocaleId = appContext.CurrentTenant.DefaultLocale.LCID;
            var path = BuildPathSegments(url, isUrlAbsolute, parentPageId, tenantId, localeId, defaultLocaleId);

            path = AddLeadingSlash(path);
            path = AddLocale(path, localeId, defaultLocaleId);
            path = RemoveTrailingSlash(path);

            return path;
        }

        protected virtual string BuildPathSegments(string url, bool isUrlAbsolute, Guid parentPageId, int tenantId, int localeId, int defaultLocaleId)
        {
            var result = url;

            if (!isUrlAbsolute)
            {
                // This list is pulled from the request cache.
                var pageList = parentUrlPageListFactory.GetParentUrlPageList(tenantId);
                var parentUrl = GetParentPageUrl(parentPageId, localeId, pageList);
                result = JoinUrlSegments(parentUrl, url);
            }
            return result;
        }

        protected virtual string GetParentPageUrl(Guid parentPageId, int localeId, ParentUrlPageList pageList)
        {
            var result = "";
            if (!parentPageId.Equals(Guid.Empty))
            {
                var parentPage = pageList.Where(x => x.Id == parentPageId && x.LocaleId == localeId).FirstOrDefault();
                if (parentPage != null)
                {
                    if (!parentPage.IsUrlAbsolute)
                    {
                        result = JoinUrlSegments(GetParentPageUrl(parentPage.ParentId, localeId, pageList), parentPage.Url);
                    }
                    else
                    {
                        result = parentPage.Url;
                    }
                }
            }
            return result;
        }

        protected virtual string JoinUrlSegments(string firstSegment, string secondSegment)
        {
            if (String.IsNullOrEmpty(firstSegment))
            {
                return secondSegment;
            }
            if (String.IsNullOrEmpty(secondSegment))
            {
                return firstSegment;
            }
            bool firstHasSlash = firstSegment.EndsWith("/");
            bool lastHasSlash = secondSegment.StartsWith("/");
            if (!firstHasSlash && !lastHasSlash)
            {
                return firstSegment + "/" + secondSegment;
            }
            else if (firstHasSlash && lastHasSlash)
            {
                return firstSegment + secondSegment.Substring(1);
            }
            else
            {
                return firstSegment + secondSegment;
            }
        }

        protected virtual string RemoveTrailingSlash(string path)
        {
            if (path.Length > 1 && path.EndsWith("/"))
            {
                path = path.Substring(0, path.Length - 1);
            }
            return path;
        }

        protected virtual string AddLeadingSlash(string path)
        {
            if (!path.StartsWith("/"))
            {
                path = "/" + path;
            }
            return path;
        }

        protected virtual string AddLocale(string path, int localeId, int defaultLocaleId)
        {
            // If this is the default locale, leave the path alone
            if (localeId != defaultLocaleId && IsValidLocaleId(localeId))
            {
                var locale = new CultureInfo(localeId);
                path = "/" + locale.Name.ToLowerInvariant() + path;
            }

            return path;
        }

        protected virtual bool IsValidLocaleId(int localeId)
        {
            return
                CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .Any(c => c.LCID == localeId);
        }

        // TODO: Add a way to put an extension on the Urls
    }
}
