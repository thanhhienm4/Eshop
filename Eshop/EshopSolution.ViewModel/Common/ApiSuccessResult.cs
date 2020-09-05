using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.ViewModel.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult() { }
        public ApiSuccessResult(T resultObj)
        {
            IsSuccessed = true;
            ResultObj = resultObj;
        }
    }
}
