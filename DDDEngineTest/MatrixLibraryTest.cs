using MathNet.Numerics.LinearAlgebra.Double;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDEngineTest
{
    [TestClass]
    public class MatrixLibraryTest
    {
        [TestMethod]
        public void TestMultiplication()
        {
            var m1 = DenseMatrix.OfArray(new double[,]
            {
                {1, 2, 3}
            });

            var m2 = DenseMatrix.OfArray(new double[,]
            {
                {2, 0, 0},
                {0, 2, 0},
                {0, 0, 2}
            });
            var result = m1.Multiply(m2);
            var actialRowArrays = result.ToRowArrays();
            var expectedRowArrays = new[]
            {
                new []{2.0, 4.0, 6.0}
            };
            Assert.AreEqual(expectedRowArrays[0].Length, actialRowArrays[0].Length);
            for (int i = 0; i < expectedRowArrays.Length; ++i)
            {
                Assert.AreEqual(expectedRowArrays[0][i], actialRowArrays[0][i]);
            }
        }
    }
}
