using ASF.Data;

namespace ASF.Business
{
    public class AbstractBussiness
    {
        protected LeatherContext GetDbContext()
        {
            return  new LeatherContext();
        }
    }
}