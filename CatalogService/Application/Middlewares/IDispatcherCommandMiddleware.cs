using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Middlewares
{
    public interface IDispatcherCommandMiddleware<TRequest>
    {
        Task Handle(TRequest request, Func<Task> next);
    }
}
