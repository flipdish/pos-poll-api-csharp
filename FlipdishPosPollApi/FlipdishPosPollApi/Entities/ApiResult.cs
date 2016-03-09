namespace FlipdishPosPollApi.Entities
{
    public class ApiResult
    {
        public ApiResult()
            : this(null)
        {
        }

        public ApiResult(object data)
        {
            Data = data;
            Success = true;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public string UserMessage { get; set; }
        public string DeveloperMessage { get; set; }
        public string StackTrace { get; set; }
    }
}