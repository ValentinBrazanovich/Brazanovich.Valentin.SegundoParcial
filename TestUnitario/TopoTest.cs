using Roedores;

namespace TestUnitario
{
    [TestClass]
    public class TopoTest
    {
        /// <summary>
        /// Verifica que 2 topos con características idénticas de resultado true
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadTopo_Ok()
        {
            //Arrange
            Topo t1 = new Topo("Top", 0.4, ETipoAlimentacion.Carnivoro, 3.25, true);
            Topo t2 = new Topo("Top", 0.4, ETipoAlimentacion.Carnivoro, 3.25, true);

            //Act
            bool rta = t1 == t2;

            //Assert
            Assert.IsTrue(rta, "Topos con características idénticas deberían ser iguales");
        }

        /// <summary>
        /// Verifica que 2 topos con características distintas de resultado false
        /// Esto se prueba con cada característica
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadTopo_Falla()
        {
            Topo t1 = new Topo("Top", 60, ETipoAlimentacion.Herbivoro, 3.25, true);
            Topo t2 = new Topo("Top", 60, ETipoAlimentacion.Carnivoro, 3.25, true);

            Topo t3 = new Topo("Top", 60, ETipoAlimentacion.Carnivoro, 3.25, true);
            Topo t4 = new Topo("opo", 60, ETipoAlimentacion.Carnivoro, 3.25, true);

            Topo t5 = new Topo("Top", 60, ETipoAlimentacion.Carnivoro, 3.25, true);
            Topo t6 = new Topo("Top", 60.1, ETipoAlimentacion.Carnivoro, 3.25, true);

            Topo t7 = new Topo("Top", 60, ETipoAlimentacion.Carnivoro, 3.25, true);
            Topo t8 = new Topo("Top", 60, ETipoAlimentacion.Carnivoro, 4.26, true);

            Topo t9 = new Topo("Top", 60, ETipoAlimentacion.Carnivoro, 3.25, true);
            Topo t10 = new Topo("Top", 60, ETipoAlimentacion.Carnivoro, 3.25, false);


            Assert.IsFalse(t1 == t2, "Topos con diferente tipo de alimentación no deberían ser iguales.");
            Assert.IsFalse(t3 == t4, "Topos con diferente nombre no deberían ser iguales.");
            Assert.IsFalse(t5 == t6, "Topos con diferente peso no deberían ser iguales.");
            Assert.IsFalse(t7 == t8, "Topos con diferente longitud de cola no deberían ser iguales.");
            Assert.IsFalse(t9 == t10, "Topos con diferente pelaje no deberían ser iguales.");
        }

        /// <summary>
        /// Verifica que 2 topos sean iguales
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadToposNulos()
        {
            Topo? t1 = null;
            Topo? t2 = null;

            Assert.IsTrue(t1 == t2);
        }

        /// <summary>
        /// Verifica que el topo "por default" no sea nulo
        /// </summary>
        [TestMethod]
        public void TopoDefault()
        {
            Topo t = new Topo();

            Assert.IsNotNull(t);
        }

    }
}