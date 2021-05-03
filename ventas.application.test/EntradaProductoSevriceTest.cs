using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.infrastructure;

namespace ventas.application.test
{
  public  class EntradaProductoSevriceTest
    {
        private ventasContext _dbContext;
        private  ProductoEntradaService _entradaService;//SUT - Objeto bajo prueba

        //se ejecuta una vez por cada prueba //hace parte del Arrange
        [SetUp]
        public void Setup()
        {
            //Arrange
            var optionsSqlite = new DbContextOptionsBuilder<ventasContext>()
           .UseSqlite(@"Data Source=ventasDataBaseTest.db")
           .Options;

            _dbContext = new ventasContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _entradaService = new ProductoEntradaService(
                new UnitOfWork(_dbContext),
                new ProductoRepository(_dbContext));
              
        }
    }
}
