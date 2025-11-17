using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoinManagerTests
{
    private GameObject coinManagerObject;
    private CoinManager coinManager;

    [SetUp]
    public void SetUp()
    {
        // Crear un GameObject con el componente CoinManager antes de cada prueba
        coinManagerObject = new GameObject("CoinManager");
        coinManager = coinManagerObject.AddComponent<CoinManager>();
        
        // Asegurarse de que la instancia esté configurada
        CoinManager.Instance = coinManager;
        
        // Inicializar con 100 monedas por defecto
        coinManager.ResetCoins(100);
    }

    [TearDown]
    public void TearDown()
    {
        // Limpiar después de cada prueba
        if (coinManagerObject != null)
        {
            Object.DestroyImmediate(coinManagerObject);
        }
        CoinManager.Instance = null;
    }

    //[Test]
    public void Test1AddCoins()
    {
        // Arrange: Comenzar con 100 monedas
        int initialCoins = coinManager.GetTotalCoins();
        int coinsToAdd = 25;

        // Act: Agregar 25 monedas
        coinManager.AddCoins(coinsToAdd);

        // Assert: Verificar que ahora tenga 125 monedas
        Assert.AreEqual(initialCoins + coinsToAdd, coinManager.GetTotalCoins(),
            "Las monedas no se sumaron correctamente");
    }

    //[Test]
    public void Test2AddCoins()
    {
        // Arrange: Resetear a 50 monedas
        coinManager.ResetCoins(50);
        int coinsToAdd = 100;

        // Act: Agregar 100 monedas
        coinManager.AddCoins(coinsToAdd);

        // Assert: Verificar que ahora tenga 150 monedas
        Assert.AreEqual(150, coinManager.GetTotalCoins(),
            "El total de monedas después de agregar no es correcto");
    }

    //[Test]
    public void Test3AddCoins()
    {
        // Arrange: Comenzar con 0 monedas
        coinManager.ResetCoins(0);
        
        // Act: Agregar múltiples cantidades
        coinManager.AddCoins(25);
        coinManager.AddCoins(50);
        coinManager.AddCoins(100);

        // Assert: Verificar que el total sea 175
        Assert.AreEqual(175, coinManager.GetTotalCoins(),
            "La suma acumulativa de monedas no funciona correctamente");
    }

    // ========== PRUEBAS PARA EL MÉTODO SpendCoins ==========

    //[Test]
    public void Test1SpendCoins()
    {
        // Arrange: Comenzar con 100 monedas
        coinManager.ResetCoins(100);
        int coinsToSpend = 30;

        // Act: Gastar 30 monedas
        bool success = coinManager.SpendCoins(coinsToSpend);

        // Assert: Verificar que la operación fue exitosa y quedan 70 monedas
        Assert.IsTrue(success, "SpendCoins debería retornar true cuando hay suficientes monedas");
        Assert.AreEqual(70, coinManager.GetTotalCoins(),
            "Las monedas no se restaron correctamente");
    }

    //[Test]
    public void Test2SpendCoins()
    {
        // Arrange: Comenzar con 50 monedas
        coinManager.ResetCoins(50);
        int coinsToSpend = 100;

        // Act: Intentar gastar 100 monedas (más de las que hay)
        bool success = coinManager.SpendCoins(coinsToSpend);

        // Assert: Verificar que la operación falla y las monedas no cambian
        Assert.IsFalse(success, "SpendCoins debería retornar false cuando no hay suficientes monedas");
        Assert.AreEqual(50, coinManager.GetTotalCoins(),
            "Las monedas no deberían cambiar cuando no hay suficientes");
    }

   //[Test]
    public void Test3SpendCoins()
    {
        // Arrange: Comenzar con exactamente 100 monedas
        coinManager.ResetCoins(100);
        int coinsToSpend = 100;

        // Act: Gastar exactamente todas las monedas
        bool success = coinManager.SpendCoins(coinsToSpend);

        // Assert: Verificar que la operación fue exitosa y quedan 0 monedas
        Assert.IsTrue(success, "SpendCoins debería retornar true cuando se gastan exactamente todas las monedas");
        Assert.AreEqual(0, coinManager.GetTotalCoins(),
            "Deberían quedar 0 monedas después de gastar todas");
    }

}