﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Domain.Errors
{
    public class ErrorResponseBase
    {
        public ErrorModel? Error { get; set; }
    }
}
