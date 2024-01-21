namespace ProcessHub.Services
{
    public interface IProcessService
    {
        int InitiateProcess(string name);

        void RunProcess(int taskHash);

        void CancelProcess(int taskHash);
    }

    public class ProcessService : IProcessService
    {
        Random random = new Random();

        public int InitiateProcess(string name)
        {
            return random.Next();
        }

        public void RunProcess(int taskHash)
        {
        }

        public void CancelProcess(int taskHash)
        {
        }

    }
}
