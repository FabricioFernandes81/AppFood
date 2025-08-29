﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : class
    {
        Task<TResult> Handle(TQuery query);
    }
}
