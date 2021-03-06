﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ComplexCommerce.Web.Mvc.Globalization.ValidationMessages
{
    /// <summary>
    /// Context used when fetching the string from one of the <see cref="IValidationMessageProvider"/>.
    /// </summary>
    public interface IMessageContext
    {
        /// <summary>
        /// Gets attribute to get a message for
        /// </summary>
        ValidationAttribute Attribute { get; }

        /// <summary>
        /// Gets type for the model that the property exists in
        /// </summary>
        Type ContainerType { get; }

        /// <summary>
        /// Gets property that the attribute is for
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Gets culture that we want a message for
        /// </summary>
        CultureInfo CultureInfo { get; }
    }
}
