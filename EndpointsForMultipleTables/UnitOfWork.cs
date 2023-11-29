using EndpointsForMultipleTables.Interface;
using EndpointsForMultipleTables.Models;

namespace EndpointsForMultipleTables
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly TaskDatabaseContext _context;
        public IDepartment department { get;}
        public IEmployee employee { get;}

        public UnitOfWork(TaskDatabaseContext context, IDepartment department, IEmployee employee)
        {
            _context = context;
            this.department = department;
            this.employee = employee;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        //to free up connections and other scarce resources after they are no longer needed
        public void Dispose()
        {
            //clean up resources used by this class.
            Dispose(true);
            GC.SuppressFinalize(this);//it prevents objects from being garbage collected
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
