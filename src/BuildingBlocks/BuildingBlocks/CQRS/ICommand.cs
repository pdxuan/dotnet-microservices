using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    /// <summary>
    /// In MediaR Unit represent for void(not return value) -> So we separate two Interface for that reason: One return value, one not 
    /// </summary>
    public interface ICommand : ICommand<Unit>
    {

    }


    public interface ICommand<out TResponse> : IRequest<TResponse>
    {


    }
}
