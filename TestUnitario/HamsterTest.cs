using Roedores;

namespace TestUnitario
{
    [TestClass]
    public class HamsterTest
    {
        /// <summary>
        /// Verifica que 2 hámsters con características idénticas de resultado true
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadHamsters_Ok()
        {
            //Arrange
            Hamster h1 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, true);
            Hamster h2 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, true);

            //Act
            bool rta = h1 == h2;

            //Assert
            Assert.IsTrue(rta, "Hámsters con características idénticas deberían ser iguales");
        }

        /// <summary>
        /// Verifica que 2 Hámsters con características distintas de resultado false
        /// Esto se prueba con cada característica
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadHamsters_Falla()
        {
            Hamster h1 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, true);
            Hamster h2 = new Hamster("Haru", 50, ETipoAlimentacion.Omnivoro, 2, true);

            Hamster h3 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, true);
            Hamster h4 = new Hamster("Hammy", 50, ETipoAlimentacion.Herbivoro, 2, true);

            Hamster h5 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, true);
            Hamster h6 = new Hamster("Haru", 45, ETipoAlimentacion.Herbivoro, 2, true);

            Hamster h7 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, true);
            Hamster h8 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 3, true);

            Hamster h9 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, true);
            Hamster h10 = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 2, false);


            Assert.IsFalse(h1 == h2, "Hamsters con diferente tipo de alimentación no deberían ser iguales.");
            Assert.IsFalse(h3 == h4, "Hamsters con diferente nombre no deberían ser iguales.");
            Assert.IsFalse(h5 == h6, "Hamsters con diferente peso no deberían ser iguales.");
            Assert.IsFalse(h7 == h8, "Hamsters con diferente longitud no deberían ser iguales.");
            Assert.IsFalse(h9 == h10, "Hamsters con diferente vida nocturna no deberían ser iguales.");
        }

        /// <summary>
        /// Verifica que 2 hámsters sean iguales
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadHamstersNulos()
        {
            Hamster? h1 = null;
            Hamster? h2 = null;

            Assert.IsTrue(h1 == h2);
        }

        /// <summary>
        /// Verifica que el hámster "por default" no sea nulo
        /// </summary>
        [TestMethod]
        public void HamsterDefault()
        {
            Hamster h = new Hamster();

            Assert.IsNotNull(h);
        }

    }
}