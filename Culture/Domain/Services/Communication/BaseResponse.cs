namespace Culture.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        
        public T Resource { get; private set; }

        public bool Success { get;  private     set; }
        public string Message { get;private     set; }
        
        public BaseResponse( string message)
        {
            Success =false;
            Message = message;
            Resource = default;
        }

        public BaseResponse(T resource)
        {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }
       
        
    }
}