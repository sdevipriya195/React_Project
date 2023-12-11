namespace VideoRentalApp.Exceptions
{
    public class NoMovieIdException : Exception
    {
        string message;
        public NoMovieIdException()
        {
            message = "The movie with this Id is not available";
        }
        public override string Message => message;
    }
}
