using XIVApi.Endpoints.Interfaces;

namespace XIVApi
{
    public interface IXIVApi
    {
        ICharacterEndpoint Character { get; }
    }
}