namespace AuthorAPI
{
    public class CustomException : Exception
    {
        public override string Message => checkMsg(base.Message);
        public string checkMsg(string message)
        {
            return "Error while retrieving data" + message;
        }
    }
}
