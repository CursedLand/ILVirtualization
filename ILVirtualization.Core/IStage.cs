namespace ILVirtualization.Core
{
    public interface IStage
    {
        public void Execute(Context context);
        
        public string Name
        {
            get;
        }
    }
}