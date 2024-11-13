namespace VerifyPhoneNumber.API.Utils
{
    public class ServiceResponse<T> where T : IServiceResponse
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; } = default!;
        public T ResultData { get; set; } = default!;
        public ServiceResponse() { }

    }

    public interface IServiceResponse
    {
    }

    public class ServiceResponse
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; } = default!;
        public ServiceResponse() { }
    }

}
