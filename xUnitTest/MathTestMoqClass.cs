using MathLib;
using Moq;

namespace xUnitTest
{
    public class MathTestMoqClass
    {
        [Fact]
        public void ToplamaTest()
        {
            #region Arrange
            // Mock sınıfı hangi interface ile çalışacağını bilmek ister 
            var dortIslem = new Mock<IDortIslem>();
            #endregion

            #region Act // Test edilecek methodun alacağı paramtreler ve calıştırma aşaması
            /*
                İnteface içerisinde simulasyonu yapılacak method setup configure edilir.
            */
            dortIslem.Setup(p => p.Toplama(1, 2)).Returns(3);

            /* 
                Simulasyon ayarlarını bitirdikten sonra Mock nesnesinden Object property'si ile üretilen
                Method çağırılmaktadır.
            */

            int sonuc = dortIslem.Object.Toplama(1, 2);
            #endregion

            #region Assert
            Assert.Equal(3, sonuc);
            #endregion
        }

        [Fact]
        public void BolmeTesti()
        {
            DortIslem islem = new DortIslem();
            // Thorow : Bir methodun fırlattığı exception'ı test etmeye yarar.
            var dortIslem = new Mock<IDortIslem>();
            dortIslem.Setup(p => p.Bolme(1, 2)).Throws<DivideByZeroException>();

            var exception = Assert.Throws<DivideByZeroException>(() => islem.Bolme(1, 0));
        }
    }
}
