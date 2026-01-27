namespace DatabaseConnection
{
    public class DatabaseConnection
    {
        public bool IsConnected { get; private set; }

        public void Connect()
        {
            // In a real scenario, this would involve actual database connection logic.
            IsConnected = true;
        }

        public void Disconnect()
        {
            // In a real scenario, this would involve actual database disconnection logic.
            IsConnected = false;
        }
    }
}
