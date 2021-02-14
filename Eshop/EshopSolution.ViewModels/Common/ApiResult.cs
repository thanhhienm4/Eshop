namespace EshopSolution.ViewModels.Common
{
    public class ApiResult<T>
    {
        public ApiResult()
        {
        }

        public ApiResult(bool isSuccessed, string mesage, T resultObj)
        {
            IsSuccessed = isSuccessed;
            ResultObj = resultObj;
        }

        public ApiResult(bool isSuccessed, string mesage)
        {
            IsSuccessed = isSuccessed;
            Message = mesage;
        }

        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T ResultObj { get; set; }
    }
}