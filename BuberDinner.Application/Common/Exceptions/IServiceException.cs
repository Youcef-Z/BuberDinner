﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Common.Exceptions;
public interface IServiceException {

    public string ErrorMessage { get; }

    public HttpStatusCode StatusCode { get; }
}
