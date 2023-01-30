using MathLib;

namespace xUnitTest
{
    public class MathTestClass
    {
        [Fact] // -> Eğer test methodu herhangi bir parametre almıyorsa Fact olarak işaretlenir.
        public void ToplamaTest()
        {

            #region Arrange
            DortIslem dortIslem = new DortIslem();
            #endregion

            #region Act // Test edilecek methodun alacağı paramtreler ve calıştırma aşaması
            int sayi1 = 5;
            int sayi2 = 6;
            int beklenen = 11;
            int sonuc = dortIslem.Toplama(sayi1, sayi2);
            #endregion

            #region Assert
            Assert.Equal(beklenen, sonuc);
            #endregion

        }

        /*
         Eğer Test Methodumuz parametre alıyorsa 'Theory' attribute ile işaretlenir.
         Alınan değerlere InlineData ile belirtiliyor.
        */
        [Theory]
        [InlineData(3, 5, 8)] // Eğer ki birden fazla data ile test edilecek ise InlineData Attribute birden fazla kullanılır.
        [InlineData(1, 3, 4)]
        [InlineData(2, 4, 6)]
        [InlineData(5, 7, 12)]
        public void ToplamaTest2(int sayi1, int sayi2, int beklenen)
        {
            #region Arrange
            DortIslem dortIslem = new DortIslem();
            #endregion

            #region Act // Test edilecek methodun alacağı paramtreler ve calıştırma aşaması
            int sonuc = dortIslem.Toplama(sayi1, sayi2);
            #endregion

            #region Assert
            Assert.Equal(beklenen, sonuc);
            #endregion

        }

        /* 
            Eğer test edilecek data sayısı azla ile InlineData Attribute kullanılır.
            Dikkat edilmesi gereken durum MemberData'nın kullanacağı data tipi Static ve sayılabilir object türü olmalıdır.
            Yani IEnumerable<object[]> şeklinde olmalıdır.
            MemberData attribute'une bir method ismide geçilebilir. 
         */

        public static IEnumerable<object[]> testDatasi()
        {
            return new List<object[]>
            {
                new object[] {3,5,8},
                new object[] {1,4,5},
                new object[] {2,5,7},
                new object[] {3,6,9},
            };
        }
        [Theory]
        [MemberData(nameof(testDatasi))]
        public void ToplamaTest3(int sayi1, int sayi2, int beklenen)
        {
            #region Arrange
            DortIslem dortIslem = new DortIslem();
            #endregion

            #region Act // Test edilecek methodun alacağı paramtreler ve calıştırma aşaması
            int sonuc = dortIslem.Toplama(sayi1, sayi2);
            #endregion

            #region Assert
            Assert.Equal(beklenen, sonuc);
            #endregion
        }


        /*
         Eger Veriler baska bir class icerisinde olsaydi ne olurdu
         */
        [Theory]
        [MemberData(nameof(Veriler.testDatasi), MemberType = typeof(Veriler))]
        public void ToplamaTest4(int sayi1, int sayi2, int beklenen)
        {
            #region Arrange 
            DortIslem dortIslem = new DortIslem();
            #endregion

            #region Act  // Test edilecek metodun alacagi parametreler ve calistirma asamasi
            int sonuc = dortIslem.Toplama(sayi2, sayi1);
            #endregion

            #region Assert
            Assert.Equal(beklenen, sonuc);
            #endregion
        }


        /* 
            TestExplorer uzerinde sadece tek bir sonuc seti olarak gelmesi istenirse 
            DisableDiscoveryEnumaration proper
        */
        [Theory]
        [MemberData(nameof(Veriler.testDatasi),
            MemberType = typeof(Veriler), DisableDiscoveryEnumeration = true)]
        public void ToplamaTest5(int sayi1, int sayi2, int beklenen)
        {
            #region Arrange 
            DortIslem dortIslem = new DortIslem();
            #endregion

            #region Act  // Test edilecek metodun alacagi parametreler ve calistirma asamasi
            int sonuc = dortIslem.Toplama(sayi2, sayi1);
            #endregion

            #region Assert
            Assert.Equal(beklenen, sonuc);
            #endregion
        }
    }
}
