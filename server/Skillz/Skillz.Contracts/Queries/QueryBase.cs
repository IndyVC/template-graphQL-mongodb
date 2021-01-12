using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Queries
{
    public class QueryBase<T> : IRequest<T> where T : class
    {

    }
}
