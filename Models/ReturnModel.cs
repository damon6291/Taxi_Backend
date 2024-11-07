namespace Taxi_Backend.Models
{
    public class ReturnModel
    {
        public bool IsSuccess { get; set; } = false;
        public bool IsLogout { get; set; } = false;
        public object Result { get; set; } = new object();
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public ReturnModel Fail(string str)
        {
            IsSuccess = false;
            ErrorMessages.Add(str);
            return this;
        }
        public ReturnModel Fail(List<string> str)
        {
            IsSuccess = false;
            ErrorMessages = str;
            return this;
        }
        public ReturnModel Fail()
        {
            IsSuccess = false;
            return this;
        }
        public ReturnModel Logout()
        {
            IsSuccess = false;
            IsLogout = true;
            ErrorMessages.Add("Please log in again");
            return this;
        }
        public ReturnModel Success(object data)
        {
            IsSuccess = true;
            Result = data;
            return this;
        }
        public ReturnModel Success()
        {
            IsSuccess = true;
            return this;
        }
    }
}
