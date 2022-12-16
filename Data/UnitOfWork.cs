namespace TP4.Data
{
    public class UnitOfWork : IUnitofWork
    {
        public readonly UniversityContext _universityContext;
        public StudentRepository Students
        {
            get;
        }

        public bool Complete()
        {
            try 
            {
                int result = _universityContext.SaveChanges();
                if (result > 0)
                    return true;
                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
