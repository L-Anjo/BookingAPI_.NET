using EzBooking.Data;
using EzBooking.Models;

namespace EzBooking
{


    namespace EzBooking
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
                if (!dataContext.Houses.Any())
                {
                    // Popule a tabela House com alguns dados iniciais
                    var houses = new House[]
                    {
                    new House
                    {
                        name = "Casa 1",
                        doorNumber = 123,
                        // Outros campos
                    },
                    new House
                    {
                        name = "Casa 2",
                        doorNumber = 456,
                        // Outros campos
                    },
                        // Adicione mais casas conforme necessário
                    };

                    dataContext.Houses.AddRange(houses);
                    dataContext.SaveChanges();
                }

                if (!dataContext.StatusHouses.Any())
                {
                    // Popule a tabela StatusHouse com alguns dados iniciais
                    var statusHouses = new StatusHouse[]
                    {
                    new StatusHouse
                    {
                        name = "Disponível",
                    },
                    new StatusHouse
                    {
                        name = "Reservado",
                    },
                        // Adicione mais status conforme necessário
                    };

                    dataContext.StatusHouses.AddRange(statusHouses);
                    dataContext.SaveChanges();
                }

                if (!dataContext.PostalCodes.Any())
                {
                    // Popule a tabela PostalCode com alguns dados iniciais
                    var postalCodes = new PostalCode[]
                    {
                    new PostalCode
                    {
                        postalCode = 12345,
                        concelho = "Lisboa",
                        district = "Lisboa",
                    },
                    new PostalCode
                    {
                        postalCode = 54321,
                        concelho = "Porto",
                        district = "Porto",
                    },
                        // Adicione mais códigos postais conforme necessário
                    };

                    dataContext.PostalCodes.AddRange(postalCodes);
                    dataContext.SaveChanges();
                }
            }
        }
    }

}
