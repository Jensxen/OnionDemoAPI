using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.IRepository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class HostCommand : IHostCommand
{
    private readonly IHostRepository _hostRepository;
    private readonly IUnitOfWork _uow;

    public HostCommand(IHostRepository hostRepository, IUnitOfWork uow)
    {
        _hostRepository = hostRepository;
        _uow = uow;
    }

    void IHostCommand.AddHost(AddHostDto addHostDto)
    {
        try
        {
            _uow.BeginTransaction();
            var host = Host.Create(addHostDto.Id);
            _hostRepository.AddHost(host);
            _uow.Commit();
        }
        catch (Exception e)
        {
            _uow.Rollback();
            throw;
        }
    }

    public void UpdateHost(UpdateHostDto UpdateHostDto)
    {
        try
        {
            _uow.BeginTransaction();

            var host = _hostRepository.GetHost(UpdateHostDto.Id);
            if (host == null)
            {
                throw new KeyNotFoundException($"Host: {UpdateHostDto.Id} not found");
            }
            host.Update();

            _hostRepository.UpdateHost(host, UpdateHostDto.RowVersion);
            _uow.Commit();
        }
        catch (Exception e)
        {
            _uow.Rollback();
            throw;
        }
    }

    public void DeleteHost(DeleteHostDto DeleteHostDto)
    {
        try
        {
            _uow.BeginTransaction();

            var host = _hostRepository.GetHost(DeleteHostDto.Id);
            if (host == null)
            {
                throw new KeyNotFoundException($"Host: {DeleteHostDto.Id} not found");
            }
            host.Delete();

            _uow.Commit();
        }
        catch (Exception e)
        {
            _uow.Rollback();
            throw;
        }
    }
}