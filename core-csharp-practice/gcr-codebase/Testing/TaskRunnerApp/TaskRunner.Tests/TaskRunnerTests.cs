using NUnit.Framework;

namespace TaskRunner.Tests
{
    public class TaskRunnerTests
    {
        private TaskRunner _taskRunner;

        [SetUp]
        public void Setup()
        {
            _taskRunner = new TaskRunner();
        }

        [Test]
        [Timeout(2000)]
        public void LongRunningTask_ShouldFailWithTimeout()
        {
            var result = _taskRunner.LongRunningTask();
            Assert.That(result, Is.EqualTo("Task Complete"));
        }
    }
}
