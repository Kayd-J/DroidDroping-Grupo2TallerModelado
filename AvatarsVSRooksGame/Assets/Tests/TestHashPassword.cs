using NUnit.Framework;

public class TestHashPassword
{
    [Test]
    public void Test1HashPassword_KnownValue()
    {
        string hash = PasswordHasher.HashPassword("abc");
        // SHA256("abc") known value
        Assert.AreEqual("ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad", hash);
    }

    [Test]
    public void Test2HashPassword_SameInputSameHash()
    {
        string a = PasswordHasher.HashPassword("password123");
        string b = PasswordHasher.HashPassword("password123");
        Assert.AreEqual(a, b);
    }

    [Test]
    public void Test3HashPassword_DifferentInputsDifferent()
    {
        string a = PasswordHasher.HashPassword("one");
        string b = PasswordHasher.HashPassword("two");
        Assert.AreNotEqual(a, b);
    }
}
