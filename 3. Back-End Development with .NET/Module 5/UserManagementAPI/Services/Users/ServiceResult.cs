namespace UserManagementAPI.Services
{
    /// <summary>
    /// Generic result wrapper for service operations
    /// </summary>
    /// <typeparam name="T">The type of data returned</typeparam>
    public class ServiceResult<T>
    {
        public bool Success { get; private set; }
        public T? Data { get; private set; }
        public string? ErrorMessage { get; private set; }

        private ServiceResult() { }

        public static ServiceResult<T> SuccessResult(T data) => new()
        { 
            Success = true, 
            Data = data 
        };

        public static ServiceResult<T> Failure(string errorMessage) => new()
        { 
            Success = false, 
            ErrorMessage = errorMessage 
        };
    }
}
