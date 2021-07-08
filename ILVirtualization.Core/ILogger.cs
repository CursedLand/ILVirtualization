namespace ILVirtualization.Core
{
    public interface ILogger
    {
        void Debug(string m);
        void Info(string m);
        void Warn(string m);
    }
}