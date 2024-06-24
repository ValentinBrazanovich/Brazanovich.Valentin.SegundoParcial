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

        [TestMethod]
        public void TerrarioDefault()
        {
            Terrario t = new Terrario();

            Assert.IsNotNull(t);
        }

    }
}