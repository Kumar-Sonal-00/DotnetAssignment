namespace test
{
    public class PhoneNumberValidatorTest
    {
        [Test]
        public static void TestValidPhoneNumber()
        {
            int result = PhoneNumberValidator.PhoneNumberValidator.ValidatePhoneNumber("99-999-99999");
            Assert.AreEqual(1, result);
        }
        [Test]
        public static void TestInValidPhoneNumberWithNull()
        {
            int result = PhoneNumberValidator.PhoneNumberValidator.ValidatePhoneNumber(null);
            Assert.AreEqual(-1, result);
        }
        [Test]
        public static void TestInValidPhoneNumberWithBlank()
        {
            int result = PhoneNumberValidator.PhoneNumberValidator.ValidatePhoneNumber("");
            Assert.AreEqual(-1, result);
        }
        [Test]
        public static void TestInValidPhoneNumberWithWrongNumber()
        {
            int result = PhoneNumberValidator.PhoneNumberValidator.ValidatePhoneNumber("99-999-999-999");
            Assert.AreEqual(0, result);
        }
        [Test]
        public void TestInValidPhoneNumberWithChars()
        {
            int result = PhoneNumberValidator.PhoneNumberValidator.ValidatePhoneNumber("99-99a-999-99");
            Assert.AreEqual(0, result);
        }
    }
}