using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IDispatcher
    {

        Task Dispatch<TCommand>(TCommand command) where TCommand : class;
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : class;
    }
}
