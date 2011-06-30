namespace SiriusCybernetics
{
    public interface IVhptUserControlFactory
    {
        VhptUserControl CreateUserControl(VhptIdentification vhptId);
    }
}