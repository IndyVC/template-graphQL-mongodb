using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skillz.Contracts.Commands
{
    public class CommandBase<T> : IRequest<T> where T : class
    {

    }
}
