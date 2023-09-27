namespace Services.Interfaces;

public interface IUnitOfWork
{
    public void Begin();
    public void Commit();
    public void Rollback();
    public bool IsInTransaction();
    public void Dispose();
}
