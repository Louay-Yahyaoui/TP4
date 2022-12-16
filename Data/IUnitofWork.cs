
namespace TP4.Data
{
    public interface IUnitofWork
    {
        StudentRepository Students { get; }
        bool Complete();
    }
}
