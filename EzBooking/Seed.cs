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

            dataContext.PostalCodes.AddRange(postalCode1, postalCode2);
            dataContext.StatusHouses.AddRange(statusHouse1, statusHouse2);
            dataContext.Houses.AddRange(house1, house2);

            dataContext.SaveChanges();
        }
    }
}
