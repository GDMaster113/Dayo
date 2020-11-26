namespace Dayo
{
    public interface IStore
    {
        Note ReadMemoryList();
        void StoreMemoryList(Note note);
    }
}