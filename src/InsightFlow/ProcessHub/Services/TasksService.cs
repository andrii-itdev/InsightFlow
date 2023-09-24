namespace ProcessHub.Services
{
    public interface ITasksService
    {
        int InitiateTask(string name);

        void RunTask(int taskHash);

        void CancelTask(int taskHash);
    }

    public class TasksService : ITasksService
    {
        Random random = new Random();

        public int InitiateTask(string name)
        {
            return random.Next();
        }

        public void RunTask(int taskHash)
        {
        }

        public void CancelTask(int taskHash)
        {
        }

    }
}
