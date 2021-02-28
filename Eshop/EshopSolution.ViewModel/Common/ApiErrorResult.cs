namespace EshopSolution.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }
        public bool Trouble { get; set; }

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            Message = message;
            IsSuccessed = false;
        }
        public ApiErrorResult(bool trouble)
        {
          
            IsSuccessed = false;
            Trouble = trouble;
        }
        public ApiErrorResult(string[] validationErrors)
        {
            ValidationErrors = validationErrors;
            IsSuccessed = false;
        }
    }
}