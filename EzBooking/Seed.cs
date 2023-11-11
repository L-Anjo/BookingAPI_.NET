using System;
using System.Collections.Generic;
using EzBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EzBooking.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {

            // Verifique se os dados já foram adicionados.
            if (dataContext.PostalCodes.Any() || dataContext.StatusHouses.Any() || dataContext.Houses.Any())
            {
                return; // O banco de dados já está populado.
            }

            // Adicione dados de exemplo aqui
            var postalCode1 = new PostalCode
            {
                postalCode = 4750,
                concelho = "Barcelos",
                district = "Braga"
            };

            var postalCode2 = new PostalCode
            {
                postalCode = 4500,
                concelho = "Matosinhos",
                district = "Porto"
            };

            var statusHouse1 = new StatusHouse
            {
                name = "Suspensa"
            };

            var statusHouse2 = new StatusHouse
            {
                name = "Disponivel"
            };

            var house1 = new House
            {
                name = "Example House 1",
                doorNumber = 123,
                floorNumber = 2,
                price = 100.0,
                guestsNumber = 4,
                road = "Example Road 1",
                propertyAssessment="dffddsf2",
                sharedRoom = false,
                PostalCode = postalCode1,
                StatusHouse = statusHouse1
            };

            var house2 = new House
            {
                name = "Example House 2",
                doorNumber = 456,
                floorNumber = 3,
                price = 150.0,
                guestsNumber = 6,
                road = "Example Road 2",
                propertyAssessment = "dffddsf3",
                sharedRoom = false,
                PostalCode = postalCode2,
                StatusHouse = statusHouse2
            };

            var user1 = new User
            {
                name = "Pedro",
                email = "pedro@alunos.ipca.pt",
                password = "password",
                phone = "123456789",
                token = "SDAD3Dasdsa2D2DAasdsASD",
                status = 1
            };

            var user2 = new User
            {
                name = "Luis",
                email = "luis@alunos.ipca.pt",
                password = "password2",
                phone = "987654321",
                token = "SADassadw232esadDSADAds-2",
                status = 1
            };

            var user3 = new User
            {
                name = "Diogo",
                email = "diogo@alunos.ipca.pt",
                password = "password3",
                phone = "12345432",
                token = "DSADxsxDDDDsXseee321",
                status = 1
            };

            var feedback1 = new Feedback
            {
                classification = 5,
                comment = "Muito bom!"
            };

            var feedback2 = new Feedback
            {
                classification = 3,
                comment = "Razoável!"
            };

            var feedback3 = new Feedback
            {
                classification = 1,
                comment = "Terrível!"
            };

            var paymentState1 = new PaymentStates
            {
                state = "Pendente"
            };

            var paymentState2 = new PaymentStates
            {
                state = "Concluido"
            };

            var paymentState3 = new PaymentStates
            {
                state = "Cancelado"
            };

            var payment1 = new Payment
            {
                creationDate = DateTime.Now,
                paymentDate = DateTime.Now,
                paymentMethod = "MbWay",
                paymentValue = 341,
                state = paymentState1
            };

            var payment2 = new Payment
            {
                creationDate = DateTime.Now,
                paymentDate = DateTime.Now,
                paymentMethod = "Paypal",
                paymentValue = 187,
                state = paymentState2
            };

            var payment3 = new Payment
            {
                creationDate = DateTime.Now,
                paymentDate = DateTime.Now,
                paymentMethod = "Multibanco",
                paymentValue = 900,
                state = paymentState3
            };

            dataContext.PostalCodes.AddRange(postalCode1, postalCode2);
            dataContext.StatusHouses.AddRange(statusHouse1, statusHouse2);
            dataContext.Houses.AddRange(house1, house2);
            dataContext.Users.AddRange(user1, user2, user3);
            dataContext.Feedbacks.AddRange(feedback1, feedback2, feedback3);
            dataContext.PaymentStates.AddRange(paymentState1, paymentState2, paymentState3);
            dataContext.Payments.AddRange(payment1, payment2, payment3);
            

            dataContext.SaveChanges();
        }
    }
}
