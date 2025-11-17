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

   
}