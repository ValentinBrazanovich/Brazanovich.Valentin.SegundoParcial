using Roedores;

namespace TestUnitario
{
    [TestClass]
    public class TerrarioTest
    {
        [TestMethod]
        public void AgregarRoedores_Ok()
        {
            // Arrange
            Terrario terrario = new Terrario();
            Hamster hamster = new Hamster("Haru", 50, ETipoAlimentacion.Herbivoro, 4, true);
            Raton raton = new Raton("Haru", 50, ETipoAlimentacion.Herbivoro, 4, true);
            Topo topo = new Topo("top", 70, ETipoAlimentacion.Carnivoro, 3.27, false);

            // Act
            terrario += hamster;
            terrario += raton;
            terrario += topo;

            // Assert
            Assert.IsTrue(terrario.Roedores.Contains(hamster));
            Assert.IsTrue(terrario.Roedores.Contains(raton));
            Assert.IsTrue(terrario.Roedores.Contains(topo));
        }

        [TestMethod]
        public void AgregarRoedores_Falla()
        {
            Terrario terrario = new Terrario();
            Hamster hamster1 = new Hamster("Haru", 45, ETipoAlimentacion.Herbivoro, 2, true);
            Hamster hamster2 = new Hamster("Haru", 45, ETipoAlimentacion.Herbivoro, 2, true);

            terrario += hamster1;
            terrario += hamster2;

            Assert.AreEqual(1, terrario.Roedores.Count); //solo debe haber un hámster
        }

        public void EliminarRoedores_Ok()
        {
            Terrario terrario = new Terrario();
            Hamster hamster = new Hamster("Hammy", 52, ETipoAlimentacion.Herbivoro, 2, true);

            terrario += hamster;
            terrario -= hamster;

            Assert.IsFalse(terrario.Roedores.Contains(hamster));
        }

        public void OrdenarPorNombre_Ascendente()
        {
            Terrario terrario = new Terrario();
            Hamster hamster = new Hamster("Zara", 50, ETipoAlimentacion.Herbivoro, 4, true);
            Topo topo = new Topo("Ana", 60, ETipoAlimentacion.Omnivoro, 7.2, true);
            terrario += hamster;
            terrario += topo;

            terrario.OrdenarPorNombre(true);

            Assert.AreEqual("Ana", terrario.Roedores[0].Nombre);
            Assert.AreEqual("Zara", terrario.Roedores[1].Nombre);
        }

        [TestMethod]
        public void OrdenarPorPeso_Descendente()
        {
            Terrario terrario = new Terrario();
            Hamster hamster = new Hamster("Zara", 48.65, ETipoAlimentacion.Herbivoro, 4.25, true);
            Raton raton = new Raton("Ana", 63.7, ETipoAlimentacion.Herbivoro, 6, true);

            terrario += hamster;
            terrario += raton;

            terrario.OrdenarPorPeso(false);

            Assert.AreEqual(63.7, terrario.Roedores[0].Peso);
            Assert.AreEqual(48.65, terrario.Roedores[1].Peso);
        }

        [TestMethod]
        public void TerrarioDefault()
        {
            Terrario t = new Terrario();

            Assert.IsNotNull(t);
        }

    }
}