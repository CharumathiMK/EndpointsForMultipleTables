namespace EndpointsForMultipleTables.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IDepartment department { get; }
        IEmployee employee { get; }

        //saving changes made in a context or database.
        int Complete();
    }
}
