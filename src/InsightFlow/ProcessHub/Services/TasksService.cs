namespace ProcessHub.Services
{
    public interface ITasksService
    {
        void InitiateTask(string name);

        void CancelTask(int taskHash);
    }

    public class TasksService : ITasksService
    {
        public void CancelTask(int taskHash)
        {
        }

        public void InitiateTask(string name)
        {
        }
    }
}
