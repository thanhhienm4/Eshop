namespace EshopSolution.ViewModel.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors;

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            Message = message;
            IsSuccessed = false;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            ValidationErrors = validationErrors;
            IsSuccessed = false;
        }
    }
}