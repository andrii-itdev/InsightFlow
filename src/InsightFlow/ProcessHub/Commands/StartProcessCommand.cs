namespace ProcessHub.API.Commands
{
    public class StartProcessCommand
    {
        public int Key { get; set; }

        public StartProcessCommand(int processKey)
        {
            Key = processKey;
        }
    }
}
