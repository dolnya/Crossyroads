namespace Logic
{
    public abstract class BaseState 
    {
        public abstract void InitState();
        public abstract void UpdateState();
        public abstract void DisposeState();
    } 
}
