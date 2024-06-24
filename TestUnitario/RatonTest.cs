using Roedores;

namespace TestUnitario
{
    [TestClass]
    public class RatonTest
    {
        [TestMethod]
        public void VerificarIgualdadRaton_Ok()
        {
            //Arrange
            Raton r1 = new Raton("Luis", 0.40, ETipoAlimentacion.Omnivoro, 5, true);
            Raton r2 = new Raton("Luis", 0.40, ETipoAlimentacion.Omnivoro, 5, true);

            //Act
            bool rta = r1 == r2;

            //Assert
            Assert.IsTrue(rta, "Ratones con características idénticas deberían ser iguales");
        }

        [TestMethod]
        public void VerificarIgualdadRaton_Falla()
        {
            Raton h1 = new Raton("Luis", 40, ETipoAlimentacion.Herbivoro, 5, true);
            Raton h2 = new Raton("Luis", 40, ETipoAlimentacion.Omnivoro, 5, true);

            Raton h3 = new Raton("Luis", 40, ETipoAlimentacion.Omnivoro, 5, true);
            Raton h4 = new Raton("siuL", 40, ETipoAlimentacion.Omnivoro, 5, true);

            Raton h5 = new Raton("Luis", 40, ETipoAlimentacion.Omnivoro, 5, true);
            Raton h6 = new Raton("Luis", 50, ETipoAlimentacion.Omnivoro, 5, true);

            Raton h7 = new Raton("Luis", 40, ETipoAlimentacion.Omnivoro, 5, true);
            Raton h8 = new Raton("Luis", 40, ETipoAlimentacion.Omnivoro, 7, true);

            Raton h9 = new Raton("Luis", 40, ETipoAlimentacion.Omnivoro, 5, true);
            Raton h10 = new Raton("Luis", 40, ETipoAlimentacion.Omnivoro, 5, false);


            Assert.IsFalse(h1 == h2, "Ratones con diferente tipo de alimentación no deberían ser iguales.");
            Assert.IsFalse(h3 == h4, "Ratones con diferente nombre no deberían ser iguales.");
            Assert.IsFalse(h5 == h6, "Ratones con diferente peso no deberían ser iguales.");
            Assert.IsFalse(h7 == h8, "Ratones con diferente longitud de cola no deberían ser iguales.");
            Assert.IsFalse(h9 == h10, "Ratones con diferente pelaje no deberían ser iguales.");
        }

        [TestMethod]
        public void VerificarIgualdadRatonesNulos()
        {
            Raton? r1 = null;
            Raton? r2 = null;

            Assert.IsTrue(r1 == r2);
        }

        [TestMethod]
        public void RatonDefault()
        {
            Raton r = new Raton();

            Assert.IsNotNull(r);
        }

    }
}