using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;


        public StudentTests()
        {
            _name = new Name("James", "Howlett");
            _document = new Document("35111507795", EDocumentType.CPF);
            _email = new Email("xman@marvel.com");
            _address = new Address("Rua tal", "123", "Bairro legal", "Los Angeles", "Ca", "EUA", "13400000");
            _student = new Student(_name, _document, _email);
            
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "X Corp", _document, _address, _email);

           
            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionNoPayment()
        {
            var subscription = new Subscription(null);
            _student.AddSubscription(subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment("123456789", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "X Corp", _document, _address, _email);

            subscription.AddPayment(payment);
            _student.AddSubscription(subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}
