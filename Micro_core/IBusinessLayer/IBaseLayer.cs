namespace Micro_core.IBusinessLayer
{
    public interface IBaseLayer
    {
        void SaveOrUpdate<T>(T objectT, int id) where T : class;
    }
}