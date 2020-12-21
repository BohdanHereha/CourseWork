using IIG.PasswordHashingUtils;
using System;
using Xunit;

namespace BlackBoxTesting
{
    public class BBT
    {

        [Fact]
        public void TestNotNull()
        {
            string[] password  = new string[5] { "MyPassword", "1234", "<?|@", "Привіт", " "};
            string[] salt = new string[5] { "", "Hello", "<?|@", "4234", " "};
            uint[] thirdArgument = new uint[9] { 0, 1, 30, 55, 90, 127, 500, 1000, 4294967295};


            for (int i = 0; i < 5; i++)
            {
                Assert.NotNull(PasswordHasher.GetHash(password[i]));
            }

            for (int i = 0; i < 9; i++)
            {
                Assert.NotNull(PasswordHasher.GetHash(password[0], salt[0], thirdArgument[i]));
            }
        }


        [Fact]
        public void IdenticalPasswords_1()
        {
            string password = "MyPassword";

            Assert.Equal(PasswordHasher.GetHash(password), PasswordHasher.GetHash(password));
        }

        [Fact]
        public void IdenticalPasswords_2()
        {
            string password_1 = "MyPassword";
            string password_2 = "MyPassword";

            Assert.Equal(PasswordHasher.GetHash(password_1), PasswordHasher.GetHash(password_2));
        }

        [Fact]
        public void DifferentPasswords()
        {
            string password_1 = "MyPassword_1";
            string password_2 = "MyPassword_2";

            Assert.NotEqual(PasswordHasher.GetHash(password_1), PasswordHasher.GetHash(password_2));
        }


        [Fact]
        public void IrrelevanceOfArguments()
        {
            string password = "MyPassword";
            Assert.NotEqual(PasswordHasher.GetHash(password, "Wow", null), PasswordHasher.GetHash(password, "Hello", null));
        }

        [Fact]
        public void IrrelevanceOfArguments_2()
        {
            string password = "MyPassword";
            Assert.NotEqual(PasswordHasher.GetHash(password, null, 1234), PasswordHasher.GetHash(password, null, 45667));
        }

        [Fact]
        public void CyrillicInput()
        {
            string password = "Пароль";
            Assert.NotNull(PasswordHasher.GetHash(password));
        }


        [Fact]
        public void SpaceSymbol()
        {
            string password = "Пароль !";
            Assert.NotNull(PasswordHasher.GetHash(password));
        }

        [Fact]
        public void LetterRegister()
        {
            string password_1 = "ПАРОЛЬ!";
            string password_2 = "пароль!";
            Assert.NotEqual(PasswordHasher.GetHash(password_1), PasswordHasher.GetHash(password_2));
        }

        [Fact]
        public void HashLengthIdenticalPasswords()
        {
            string password = "123456789";
            Assert.Equal(PasswordHasher.GetHash(password).Length, PasswordHasher.GetHash(password).Length);
        }

        [Fact]
        public void HashLengthDifferentPasswords()
        {
            string password_1 = "12345";
            string password_2 = "123";
            Assert.Equal(PasswordHasher.GetHash(password_1).Length, PasswordHasher.GetHash(password_2).Length);
        }

        [Fact]
        public void HashLength()
        {
            string password = "12345";
            Assert.Equal(64, PasswordHasher.GetHash(password).Length);
        }

        [Fact]
        public void ArgumentNullException()
        {
            string password = "MyPassword";
            string[] salt = new string[5] { "Сіль", "鹽", "塩", "ملح", "Тұз" };

            Assert.Throws<ArgumentNullException>(() => PasswordHasher.GetHash(null));
   
            for (int i = 0; i < 5; i++)
            {
                Assert.Throws<OverflowException>(() => PasswordHasher.GetHash(password, salt[i]));
            }

        }

    }
}
