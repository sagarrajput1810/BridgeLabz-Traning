using System.Threading;

namespace TaskRunner
{
    public class TaskRunner
    {
        public string LongRunningTask()
        {
            Thread.Sleep(3000);
            return "Task Complete";
        }
    }
}
