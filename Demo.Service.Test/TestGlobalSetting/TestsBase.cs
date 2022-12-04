namespace Demo.Service.Test.TestGlobalSetting;

public class TestsBase : IDisposable
{
    public TestsBase()
    {
        // Do "global" initialization here; Called before every test method.
    }

    public void Dispose()
    {
        // Do "global" teardown here; Called after every test method.
    }
}