namespace EncurtadorUrl.Api.Shared.Interfaces
{
    public interface ILogWriter
    {
        void Write(string path, params string[] messages);
        void Write(params string[] messages);
        void ConsoleWrite(string message, ConsoleColor color = ConsoleColor.Cyan, bool inline = false);
    }
}
