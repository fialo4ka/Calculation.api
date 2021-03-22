using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Common.ResponseModels
{
    public class DataResponceModel<T>
    {
        public T Model { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
