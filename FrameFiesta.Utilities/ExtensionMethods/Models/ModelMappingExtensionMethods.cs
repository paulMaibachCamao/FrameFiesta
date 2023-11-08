using FrameFiesta.Contracts.Models;

namespace FrameFiesta.Utilities.ExtensionMethods.Models
{
    public static class ModelMappingExtensionMethods
    {
        public static User ConvertUserDbToUser(this UserDB userDb)
        {
            return new User
            {
                Id = userDb.Id,
                Name = userDb.Name,
                Email = userDb.Email,
                IsAdmin = userDb.IsAdmin,
                Comments = userDb.Comments
            };
        }
    }
}