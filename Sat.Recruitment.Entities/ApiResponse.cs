using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Entities
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }

        public string Errors { get; set; }
    }
}
