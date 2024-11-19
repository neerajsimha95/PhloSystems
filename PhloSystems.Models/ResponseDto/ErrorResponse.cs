using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhloSystems.Domain.ResponseDto
{
    public class ErrorResponse
    {
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
