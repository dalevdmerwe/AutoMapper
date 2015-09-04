using System;
using System.Data.Common;
using System.Data.Entity;

namespace AutoMapperSamples.EF
{
    public class TestContext : TestContextBase<TestContext>, ITestContext
    {
        public DbSet<Order> OrderSet { get; set; }

        public TestContext(DbConnection dbConnection)
            : base(dbConnection)
        {
        }

        public override void Seed()
        {
            System.Diagnostics.Debug.Print("Seeding db");

            OrderSet.Add(new Order
            {
                Id = Guid.NewGuid(),
                Name = "Zalando Bestellung",
                Ordered = new DateTime(2015, 01, 14),
                Price = 150d
            });
            OrderSet.Add(new Order
            {
                Id = Guid.NewGuid(),
                Name = "Amazon Bestellung",
                Ordered = new DateTime(2015, 02, 3),
                Price = 85d
            });
            OrderSet.Add(new Order
            {
                Id = Guid.NewGuid(),
                Name = "Universalversand",
                Ordered = new DateTime(2015, 04, 20),
                Price = 33.9d
            });

            SaveChanges();
        }
    }
}