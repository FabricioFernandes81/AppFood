using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    internal class CustomValidationException : Exception
    {
        public List<string> Errors { get; }

        public CustomValidationException(IEnumerable<string> errors)
            : base(string.Join("; ", errors)) // Converte lista de erros para string
        {
            Errors = errors.ToList();
        }
    }
}
