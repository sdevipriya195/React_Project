namespace VideoRentalApp.Exceptions
{
    public class NoGenreIdException : Exception
    {
        string message;
        public NoGenreIdException()
        {
            message = "The genre with this Id is not available";
        }
        public override string Message => message;
    }
}
