using OnionDemo.Application.Command.CommandDto;

namespace OnionDemo.Application.Command;

public interface IHostCommand
{
    void AddHost(AddHostDto addHostDto);
    void UpdateHost(UpdateHostDto UpdateHostDto);
    void DeleteHost(DeleteHostDto DeleteHostDto);
}