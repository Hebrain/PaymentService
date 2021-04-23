using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        public void AdicionarAssinatura()
        {
            var subscription = new Subscription(null);
            var student = new Student("Hebra", "Tabosa", "123456789", "hello@hebra.com");
            student.AddSubscription(subscription);
        }
    }
}
