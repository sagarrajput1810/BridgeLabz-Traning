using NUnit.Framework;

namespace DatabaseConnection.Tests
{
    public class DatabaseConnectionTests
    {
        private DatabaseConnection _dbConnection;

        [SetUp]
        public void Setup()
        {
            _dbConnection = new DatabaseConnection();
            _dbConnection.Connect();
        }

        [TearDown]
        public void TearDown()
        {
            _dbConnection.Disconnect();
        }

        [Test]
        public void Connect_ShouldEstablishConnection()
        {
            Assert.That(_dbConnection.IsConnected, Is.True);
        }

        [Test]
        public void Disconnect_ShouldCloseConnection()
        {
            // Disconnect is called in TearDown, so we can check the state before that
            _dbConnection.Disconnect();
            Assert.That(_dbConnection.IsConnected, Is.False);
        }
    }
}
