namespace Api.Test.Infrastructure.Data.DBFactory
{
    using Microsoft.EntityFrameworkCore;

    public interface IDatabaseFactory
    {
        DbContext GetDatabase();
    }
}
