using HueOnlineTicketFestival.Models;

public interface IEventPictureService
{
    Task<IEnumerable<EventPicture>> GetAllEventPicturesAsync();
    Task<EventPicture> GetEventPictureByIdAsync(int id);
    Task<int> AddEventPictureAsync(EventPicture EventPicture);
    Task UpdateEventPictureAsync(int id, EventPicture EventPicture);
    Task DeleteEventPictureAsync(int id);
}
