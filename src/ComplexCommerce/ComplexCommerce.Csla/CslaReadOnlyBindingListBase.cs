﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace ComplexCommerce.Csla
{
    [Serializable]
    public class CslaReadOnlyBindingListBase<T, C> :
        Persistence.ContextualReadOnlyBindingListBase<T, C>
        where T : ReadOnlyBindingListBase<T, C>
    {
    }
}
